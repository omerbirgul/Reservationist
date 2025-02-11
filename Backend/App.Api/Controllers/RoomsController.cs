using App.Repository.Dtos.RoomDtos.Requests;
using App.Service.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{

    public class RoomsController : CustomBaseController
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roomService.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roomService.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomRequest request)
        {
            var result = await _roomService.CreateAsync(request);
            return CreateActionResult(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateRoomRequest request)
        {
            var result = await _roomService.UpdateAsync(id, request);
            return CreateActionResult(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
