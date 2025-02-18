using System.Net;
using App.Repository.Dtos.UserDtos.Requests;
using App.Repository.Dtos.UserDtos.Responses;
using App.Repository.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace App.Service.Services.UserServices;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
    {
        var user = new AppUser()
        {
            Email = request.Email,
            UserName = request.Username
        };

        var identityResult = await _userManager.CreateAsync(user, request.Password);
        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors.Select(x => x.Description).ToList();
            return ServiceResult<CreateUserResponse>.Fail(errors);
        }

        return ServiceResult<CreateUserResponse>
            .SuccessAsCreated(new CreateUserResponse(user.Id), $"api/user/{user.Id}");
    }
}