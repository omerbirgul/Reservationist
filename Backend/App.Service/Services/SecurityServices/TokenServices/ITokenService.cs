using App.Repository.Dtos.TokenDtos;
using App.Repository.Entities.Concrete;

namespace App.Service.Services.SecurityServices.TokenServices;

public interface ITokenService
{
    TokenDto GenerateToken(AppUser appUser);
}