using System.Text.Json.Serialization;
using App.Repository.Dtos.RapidApiDtos;
using App.Service.Extensions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace App.Service.Services.RapidServices;

public class BookingService : IBookingService
{
    private readonly IConfiguration _configuration;

    public BookingService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private async Task<ServiceResult<T>> FetchFromApi<T>(string apiName, string endpoint) where T: class
    {
        var apiKey = _configuration["RapidApi:Key"];
        var apiHosts = _configuration.GetSection("RapidApi:Hosts")
            .Get<Dictionary<string, string>>();
        if (!apiHosts.TryGetValue(apiName, out var hostName))
        {
            return ServiceResult<T>.Fail("Invalid Api Name");
        }

        using var client = new HttpClient();
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://{hostName}{endpoint}"),
            Headers =
            {
                { "x-rapidapi-key", apiKey },
                { "x-rapidapi-host", hostName }
            }
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(body);
        return ServiceResult<T>.Success(result);
    }

    public async Task<ServiceResult<List<GetTopMovieDto>>> MovieList()
    {
        return await FetchFromApi<List<GetTopMovieDto>>("Movie", "/imdb/top250-movies");
    }

    public async Task<ServiceResult<List<CurrencyData>>> ExchangeRatesAsync()
    {
        var result = await FetchFromApi<ExchangeRootObject>("Exchange", "/api/v1/meta/getExchangeRates?base_currency=TRY");
        if (result.IsFail)
            return ServiceResult<List<CurrencyData>>.Fail(result.ErrorMessage);

        var exchangeRates = result.Data.data.exchange_rates;
        var currencyRates = exchangeRates
            .Select(rate => new CurrencyData(rate.currency, rate.exchange_rate_buy)).ToList();
        return ServiceResult<List<CurrencyData>>.Success(currencyRates);
    }

    public async Task<ServiceResult<LocationIdDto>> GetLocationId(string cityName)
    {
        if (string.IsNullOrEmpty(cityName))
            return ServiceResult<LocationIdDto>.Fail("city name is bull or empty");
        
        var result = await FetchFromApi<LocationIdRoot>
                ("LocationId", $"/api/v1/hotels/searchDestination?query={cityName}");
        
        if (result.IsFail)
            return ServiceResult<LocationIdDto>.Fail("result hatalı");

        if (result.Data.data == null || !result.Data.data.Any())
            return ServiceResult<LocationIdDto>.Fail("locationIdDatas is empty");
        
        var locationId = result.Data.data
            .Where(x => x.search_type == "city")
            .Select(x => new LocationIdDto(x.dest_id))
            .FirstOrDefault();
        
        if (locationId is null)
            return ServiceResult<LocationIdDto>.Fail("location id not found");
        
        return ServiceResult<LocationIdDto>.Success(locationId);
    }
    
    public async Task<ServiceResult<List<SearchHotelDto>>> GetHotelsAsync(string cityName, DateTime arrival, DateTime departure)
    {
        var locationIdRequest = await GetLocationId(cityName);
        string formattedArrival = arrival.ToString("yyyy-MM-dd");
        string formattedDeparture = departure.ToString("yyyy-MM-dd");

        var apiRequest = await FetchFromApi<HotelRootObject>
        ("Hotel",
            $"/api/v1/hotels/searchHotels?dest_id={locationIdRequest.Data!.id}&search_type=CITY" +
            $"&arrival_date={formattedArrival}&departure_date={formattedDeparture}&adults=1&children_age=0%2C17&room_qty=1" +
            $"&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=USD");

        if (apiRequest.IsFail || apiRequest.Data is null)
            return ServiceResult<List<SearchHotelDto>>.Fail("request error");

        var response = apiRequest.Data.data.hotels
            .Select(x => new SearchHotelDto(x.property.name, formattedArrival, formattedDeparture, x.property.reviewScore))
            .OrderByDescending(x => x.reviewScore)
            .ToList();

        if (response is null)
            return ServiceResult<List<SearchHotelDto>>.Fail("response is null");

        return ServiceResult<List<SearchHotelDto>>.Success(response);
    }
}