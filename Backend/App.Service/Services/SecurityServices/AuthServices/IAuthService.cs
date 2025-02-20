using App.Repository.Dtos.TokenDtos;
using App.Repository.Dtos.UserDtos.Requests;

namespace App.Service.Services.SecurityServices.AuthServices;

public interface IAuthService
{
    Task<ServiceResult<TokenDto>> CreateTokenAsync(LoginRequest request);
}