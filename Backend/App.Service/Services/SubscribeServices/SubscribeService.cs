using App.Repository.Dtos.SubscribeDtos;
using App.Repository.Dtos.SubscribeDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using App.Service.Services.GenericServices;
using AutoMapper;

namespace App.Service.Services.SubscribeServices;

public class SubscribeService : GenericService<
    CreateSubscribeRequest,
    UpdateSubcsribeRequest,
    SubscribeDto,
    Subscribe>, ISubscribeService
{
    public SubscribeService(IGenericRepository<Subscribe> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(genericRepository, mapper, unitOfWork)
    {
    }
    
}