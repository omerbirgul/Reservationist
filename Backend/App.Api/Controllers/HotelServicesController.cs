using App.Repository.Dtos.HotelServiceDtos.Requests;
using App.Service.Services.HotelServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    public class HotelServicesController : CustomBaseController
    {
        private readonly IHotelService _hotelServiceService;

        public HotelServicesController(IHotelService hotelServiceService)
        {
            _hotelServiceService = hotelServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hotelServiceService.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _hotelServiceService.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHotelServiceRequest request)
        {
            var result = await _hotelServiceService.CreateAsync(request);
            return CreateActionResult(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateHotelServiceRequest request)
        {
            var result = await _hotelServiceService.UpdateAsync(id, request);
            return CreateActionResult(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hotelServiceService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
