using App.Repository.Dtos.HotelServiceDtos.Requests;
using App.Service.Dtos.HotelServiceDtos;
using App.Service.Services.GenericServices;

namespace App.Service.Services.HotelServices;

public interface IHotelService : IGenericService<
        CreateHotelServiceRequest,
        UpdateHotelServiceRequest,
        HotelServiceDto,
        Repository.Entities.Concrete.HotelService>
{
        
}