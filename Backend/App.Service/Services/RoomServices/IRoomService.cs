using App.Repository.Dtos.RoomDtos;
using App.Repository.Dtos.RoomDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Service.Services.GenericServices;

namespace App.Service.Services.RoomServices;

public interface IRoomService : IGenericService<
    CreateRoomRequest,
    UpdateRoomRequest,
    RoomDto,
    Room>
{
}