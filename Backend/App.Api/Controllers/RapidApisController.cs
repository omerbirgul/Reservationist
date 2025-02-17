using App.Service.Services.RapidServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

    public class RapidApisController : CustomBaseController
    {
        private readonly IBookingService _bookingService;

        public RapidApisController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        
        [HttpGet("GetMovieList")]
        public async Task<IActionResult> GetMovieList()
        {
            var result = await _bookingService.MovieList();
            return CreateActionResult(result);
        }

        [HttpGet("GetExhangeRates")]
        public async Task<IActionResult> GetExhangeRates()
        {
            var result = await _bookingService.ExchangeRatesAsync();
            return CreateActionResult(result);
        }
    }
