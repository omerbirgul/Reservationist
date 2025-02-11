using App.Repository.Dtos.UserDtos.Requests;
using App.Repository.Dtos.UserDtos.Responses;

namespace App.Service.Services.UserServices;

public interface IUserService
{
    Task<ServiceResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);
}