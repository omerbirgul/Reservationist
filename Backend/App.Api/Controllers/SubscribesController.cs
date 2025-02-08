using App.Service.Dtos.SubscribeDtos.Requests;
using App.Service.Services.SubscribeServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

public class SubscribesController : CustomBaseController
{
    private readonly ISubscribeService _subscribeService;

    public SubscribesController(ISubscribeService subscribeService)
    {
        _subscribeService = subscribeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _subscribeService.GetAllAsync();
        return CreateActionResult(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _subscribeService.GetByIdAsync(id);
        return CreateActionResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSubscribeRequest request)
    {
        var result = await _subscribeService.CreateAsync(request);
        return CreateActionResult(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateSubcsribeRequest request)
    {
        var result = await _subscribeService.UpdateAsync(id, request);
        return CreateActionResult(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _subscribeService.DeleteAsync(id);
        return CreateActionResult(result);
    }
}

