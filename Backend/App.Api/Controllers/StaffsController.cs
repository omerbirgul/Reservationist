using App.Repository.Dtos.StaffDtos.Requests;
using App.Service.Services.StaffServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{

    public class StaffsController : CustomBaseController
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _staffService.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _staffService.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffRequest request)
        {
            var result = await _staffService.CreateAsync(request);
            return CreateActionResult(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateStaffRequest request)
        {
            var result = await _staffService.UpdateAsync(id, request);
            return CreateActionResult(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _staffService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
