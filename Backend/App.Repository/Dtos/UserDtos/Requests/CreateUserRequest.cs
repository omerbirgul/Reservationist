namespace App.Repository.Dtos.UserDtos.Requests;

public record CreateUserRequest(string Email, string Username, string Password);