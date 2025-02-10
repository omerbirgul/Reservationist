using App.Repository.Entities.Concrete;
using App.Service.Dtos.StaffDtos;
using App.Service.Dtos.StaffDtos.Requests;
using App.Service.Dtos.StaffDtos.Responses;
using App.Service.Services.GenericServices;

namespace App.Service.Services.StaffServices;

public interface IStaffService : IGenericService<
    CreateStaffRequest,
    UpdateStaffRequest,
    StaffDto,
    Staff>
{
    
}