using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using App.Repository.Dtos.TokenDtos;
using App.Repository.Entities.Concrete;
using App.Repository.TokenConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace App.Service.Services.TokenServices;

public class TokenService
{
    private readonly CustomTokenOptions _tokenOptions;
    private readonly UserManager<AppUser> _userManager;

    public TokenService(IOptions<CustomTokenOptions> tokenOptions, UserManager<AppUser> userManager)
    {
        _tokenOptions = tokenOptions.Value;
        _userManager = userManager;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        return Convert.ToBase64String(randomNumber);
    }

    private SecurityKey GetSymetricSecurityKey(string key)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }

    public TokenDto GenerateToken(AppUser appUser)
    {
        var accessTokenExpiration = DateTime.Now
            .AddMinutes(_tokenOptions.AccessTokenExpiration);

        var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);

        var securityKey =  GetSymetricSecurityKey(_tokenOptions.SecurityKey);

        var signinCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _tokenOptions.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            signingCredentials: signinCredential
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(jwtSecurityToken);
        var tokenDto = new TokenDto(token, accessTokenExpiration, GenerateRefreshToken(), refreshTokenExpiration);

        return tokenDto;
    }
}