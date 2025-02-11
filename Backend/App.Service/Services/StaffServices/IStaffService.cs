using App.Repository.Dtos.StaffDtos;
using App.Repository.Dtos.StaffDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Service.Services.GenericServices;

namespace App.Service.Services.StaffServices;

public interface IStaffService : IGenericService<
    CreateStaffRequest,
    UpdateStaffRequest,
    StaffDto,
    Staff>
{
    
}