using App.Repository.Dtos.TokenDtos;
using App.Repository.Dtos.UserDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using App.Service.Services.SecurityServices.TokenServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Service.Services.SecurityServices.AuthServices;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IGenericRepository<UserRefreshToken> _refreshTokenRepository;

    public AuthService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ITokenService tokenService, IGenericRepository<UserRefreshToken> refreshTokenRepository)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepository;
    }


    private async Task HandleRefreshToken(string userId, TokenDto tokenDto)
    {
        var userRefreshToken = await _refreshTokenRepository
            .Where(x => x.UserId == userId).SingleOrDefaultAsync();

        if (userRefreshToken is null)
        {
            await _refreshTokenRepository.CreateAsync(new UserRefreshToken()
            {
                UserId = userId,
                Code = tokenDto.RefreshToken,
                ExpirationDate = tokenDto.RefreshTokenExpiration
            });
        }
        else
        {
            userRefreshToken.Code = tokenDto.RefreshToken;
            userRefreshToken.ExpirationDate = tokenDto.RefreshTokenExpiration;
        }

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ServiceResult<TokenDto>> CreateTokenAsync(LoginRequest request)
    {
        if(request is null)
            return ServiceResult<TokenDto>.Fail("Email or password worng");

        var user = await _userManager.FindByEmailAsync(request.Email);
        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
        if(user is null || !isPasswordCorrect)
            return ServiceResult<TokenDto>.Fail("Email or Password not found");

        var token = _tokenService.GenerateToken(user);
        await HandleRefreshToken(user.Id, token);
        return ServiceResult<TokenDto>.Success(token);
    }
}