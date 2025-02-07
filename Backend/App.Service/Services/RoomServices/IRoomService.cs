using App.Service.Dtos.RoomDtos;
using App.Service.Dtos.RoomDtos.Requests;
using App.Service.Dtos.RoomDtos.Responses;

namespace App.Service.Services.RoomServices;

public interface IRoomService
{
    Task<ServiceResult<List<RoomDto>>> GetAllAsync();
    Task<ServiceResult<RoomDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateRoomResponse>> CreateAsync(CreateRoomRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateRoomRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}