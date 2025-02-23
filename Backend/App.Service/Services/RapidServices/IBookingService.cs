using App.Repository.Dtos.RapidApiDtos;

namespace App.Service.Services.RapidServices;

public interface IBookingService
{
    Task<ServiceResult<List<GetTopMovieDto>>> MovieList();
    Task<ServiceResult<List<CurrencyData>>> ExchangeRatesAsync();
    Task<ServiceResult<LocationIdDto>> GetLocationId(string cityName);
    Task<ServiceResult<List<SearchHotelDto>>> GetHotelsAsync(string cityName, DateTime arrival, DateTime departure);
}