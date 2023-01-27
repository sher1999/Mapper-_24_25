using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;

[Route("[controller]")]

public class OrderController:ControllerBase
{

    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService=orderService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetOrderDto>>> Gett()
    {
        return await _orderService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddOrderDto>> Addd(AddOrderDto c)
    {
        if (ModelState.IsValid)
        {
            return await _orderService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddOrderDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddOrderDto>> Updatee([FromBody] AddOrderDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _orderService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddOrderDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    [HttpDelete("{id}")]
    public async Task<Response<GetOrderDto>> Deletee(int id)
    {
        return await _orderService.Delete(id);
    
    }

}






