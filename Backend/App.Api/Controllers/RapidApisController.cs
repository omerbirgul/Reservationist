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

        [HttpGet("GetLocationId")]
        public async Task<IActionResult> GetLocationId(string cityName)
        {
            var result = await _bookingService.GetLocationId(cityName);
            return CreateActionResult(result);
        }

        [HttpGet("SearchHotels")]
        public async Task<IActionResult> SearchHotels(string cityName, DateTime arrival, DateTime departure)
        {
            var result = await _bookingService.GetHotelsAsync(cityName, arrival, departure);
            return CreateActionResult(result);
        }
    }
