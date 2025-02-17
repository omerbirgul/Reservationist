using App.Repository.Dtos.RapidApiDtos;

namespace App.Service.Services.RapidServices;

public interface IBookingService
{
    Task<ServiceResult<List<GetTopMovieDto>>> ReservationList();
}