namespace App.Repository.Dtos.TokenDtos;

public record TokenDto
    (
        string AccessToken,
        DateTime AccessTokenExpiration,
        string RefreshToken,
        DateTime RefreshTokenExpiration
    );