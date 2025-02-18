using App.Repository.Dtos.UserDtos.Requests;
using App.Service.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserRequest request)
        {
            var result = await _userService.CreateUserAsync(request);
            return CreateActionResult(result);
        }
    }

