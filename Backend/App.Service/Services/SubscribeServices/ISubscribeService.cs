using App.Repository.Entities.Concrete;
using App.Service.Dtos.SubscribeDtos;
using App.Service.Dtos.SubscribeDtos.Requests;
using App.Service.Dtos.SubscribeDtos.Responses;
using App.Service.Services.GenericServices;

namespace App.Service.Services.SubscribeServices;

public interface ISubscribeService : IGenericService<
    CreateSubscribeRequest,
    UpdateSubcsribeRequest,
    SubscribeDto,
    Subscribe>
{
    
}