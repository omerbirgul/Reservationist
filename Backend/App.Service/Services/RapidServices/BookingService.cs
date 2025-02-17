using System.Text.Json.Serialization;
using App.Repository.Dtos.RapidApiDtos;
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
        var result = await FetchFromApi<RootObject>("Exchange", "/api/v1/meta/getExchangeRates?base_currency=TRY");
        if (result.IsFail)
            return ServiceResult<List<CurrencyData>>.Fail(result.ErrorMessage);

        var exchangeRates = result.Data.data.exchange_rates;
        var currencyRates = exchangeRates
            .Select(rate => new CurrencyData(rate.currency, rate.exchange_rate_buy)).ToList();
        return ServiceResult<List<CurrencyData>>.Success(currencyRates);
    }
}