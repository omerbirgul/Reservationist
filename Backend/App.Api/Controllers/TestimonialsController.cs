using App.Service.Dtos.TestimonialDtos.Requests;
using App.Service.Services.TestimonialServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

public class TestimonialsController : CustomBaseController
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialsController(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _testimonialService.GetAllAsync();
        return CreateActionResult(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _testimonialService.GetByIdAsync(id);
        return CreateActionResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTestimonialRequest request)
    {
        var result = await _testimonialService.CreateAsync(request);
        return CreateActionResult(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateTestimonialRequest request)
    {
        var result = await _testimonialService.UpdateAsync(id, request);
        return CreateActionResult(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _testimonialService.DeleteAsync(id);
        return CreateActionResult(result);
    }
}

