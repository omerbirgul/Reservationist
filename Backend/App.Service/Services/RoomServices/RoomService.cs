using System.Net;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.GenericRepositories.RoomRepositories;
using App.Repository.UnitOfWork;
using App.Service.Dtos.RoomDtos;
using App.Service.Dtos.RoomDtos.Requests;
using App.Service.Dtos.RoomDtos.Responses;
using App.Service.Services.GenericServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Service.Services.RoomServices;

public class RoomService : GenericService<
    CreateRoomRequest,
    UpdateRoomRequest,
    RoomDto,
    Room>, IRoomService
{
    public RoomService(IGenericRepository<Room> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(genericRepository, mapper, unitOfWork)
    {
    }
    
    public override async Task<ServiceResult<RoomDto>> CreateAsync(CreateRoomRequest request)
    {
             var hasRoom = await _genericRepository.Where(x => x.RoomNumber == request.RoomNumber).AnyAsync();
             if (hasRoom)
                 return ServiceResult<RoomDto>.Fail("Room already exist");
        
             var roomEntity = _mapper.Map<Room>(request);
             await _genericRepository.CreateAsync(roomEntity);
             await _unitOfWork.SaveChangesAsync();
             var response = _mapper.Map<RoomDto>(roomEntity);
             return ServiceResult<RoomDto>.SuccessAsCreated(response, $"api/room/{response.Id}");
    }

    public override async Task<ServiceResult> UpdateAsync(int id, UpdateRoomRequest request)
    {
             var room = await _genericRepository.GetByIdAsync(id);
             if (room is null)
                 return ServiceResult.Fail("No rooms found to update");
        
             var isRoomNumberExist = await _genericRepository
                 .Where(x => x.RoomNumber == request.RoomNumber && x.RoomNumber != room.RoomNumber).AnyAsync();
             if (isRoomNumberExist)
                 return ServiceResult.Fail("Room Number already exist");

             _mapper.Map(request, room);
             _genericRepository.Update(room);
             await _unitOfWork.SaveChangesAsync();
             return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}