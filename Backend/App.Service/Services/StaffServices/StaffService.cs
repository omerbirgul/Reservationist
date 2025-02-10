using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using App.Service.Dtos.StaffDtos;
using App.Service.Dtos.StaffDtos.Requests;
using App.Service.Dtos.StaffDtos.Responses;
using App.Service.Services.GenericServices;
using AutoMapper;

namespace App.Service.Services.StaffServices;

public class StaffService : GenericService<
    CreateStaffRequest,
    UpdateStaffRequest,
    StaffDto,
    Staff>, IStaffService
{
    public StaffService(IGenericRepository<Staff> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(genericRepository, mapper, unitOfWork)
    {
    }
}