using App.Repository.Entities.Concrete;
using App.Service.Dtos.RoomDtos;
using App.Service.Dtos.RoomDtos.Requests;
using App.Service.Dtos.RoomDtos.Responses;
using App.Service.Services.GenericServices;

namespace App.Service.Services.RoomServices;

public interface IRoomService : IGenericService<
    CreateRoomRequest,
    UpdateRoomRequest,
    RoomDto,
    CreateRoomResponse,
    Room>
{
}