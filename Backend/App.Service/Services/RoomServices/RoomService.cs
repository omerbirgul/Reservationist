using System.Net;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories.RoomRepositories;
using App.Repository.UnitOfWork;
using App.Service.Dtos.RoomDtos;
using App.Service.Dtos.RoomDtos.Requests;
using App.Service.Dtos.RoomDtos.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Service.Services.RoomServices;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(IRoomRepository roomRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<List<RoomDto>>> GetAllAsync()
    {
        var rooms = await _roomRepository.GetAll().ToListAsync();
        var roomDto = _mapper.Map<List<RoomDto>>(rooms);
        return ServiceResult<List<RoomDto>>.Success(roomDto);
    }

    public async Task<ServiceResult<RoomDto>> GetByIdAsync(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room is null) return ServiceResult<RoomDto>.Fail("room not found");
        var roomDto = _mapper.Map<RoomDto>(room);
        return ServiceResult<RoomDto>.Success(roomDto);
    }

    public async Task<ServiceResult<CreateRoomResponse>> CreateAsync(CreateRoomRequest request)
    {
        var hasRoom = await _roomRepository.Where(x => x.RoomNumber == request.RoomNumber).AnyAsync();
        if (hasRoom)
            return ServiceResult<CreateRoomResponse>.Fail("Room already exist");

        var roomEntity = _mapper.Map<Room>(request);
        await _roomRepository.CreateAsync(roomEntity);
        await _unitOfWork.SaveChangesAsync();
        var response = new CreateRoomResponse(roomEntity.Id);
        return ServiceResult<CreateRoomResponse>.SuccessAsCreated(response, $"api/room/{roomEntity.Id}");
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateRoomRequest request)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room is null)
            return ServiceResult.Fail("No rooms found to update");

        var isRoomNumberExist = await _roomRepository
            .Where(x => x.RoomNumber == request.RoomNumber && x.RoomNumber != room.RoomNumber).AnyAsync();
        if (isRoomNumberExist)
            return ServiceResult.Fail("Room Number already exist");

        room = _mapper.Map<Room>(request);
        _roomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room is null)
            return ServiceResult.Fail("no rooms found to delete");
        
        _roomRepository.Delete(room);
        await _unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}