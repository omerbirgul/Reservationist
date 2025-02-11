using App.Repository.Dtos.SubscribeDtos;
using App.Repository.Dtos.SubscribeDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Service.Services.GenericServices;

namespace App.Service.Services.SubscribeServices;

public interface ISubscribeService : IGenericService<
    CreateSubscribeRequest,
    UpdateSubcsribeRequest,
    SubscribeDto,
    Subscribe>
{
    
}