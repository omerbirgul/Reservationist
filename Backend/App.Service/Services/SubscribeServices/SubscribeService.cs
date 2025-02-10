using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using App.Service.Dtos.SubscribeDtos;
using App.Service.Dtos.SubscribeDtos.Requests;
using App.Service.Dtos.SubscribeDtos.Responses;
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