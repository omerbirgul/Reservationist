using App.Repository.Dtos.HotelServiceDtos.Requests;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using App.Service.Dtos.HotelServiceDtos;
using App.Service.Services.GenericServices;
using AutoMapper;
namespace App.Service.Services.HotelServices;

public class HotelService : GenericService<
    CreateHotelServiceRequest,
    UpdateHotelServiceRequest,
    HotelServiceDto,
    Repository.Entities.Concrete.HotelService>, IHotelService
{
    public HotelService(IGenericRepository<Repository.Entities.Concrete.HotelService> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
    {
    }
}