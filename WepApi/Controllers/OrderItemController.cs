using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;

[Route("[controller]")]

public class OrderItemController:ControllerBase
{

    private readonly OrderItemCervice _orderItemCervice;

    public OrderItemController(OrderItemCervice orderItemCervice)
    {
        _orderItemCervice=orderItemCervice;
    }


  
    [HttpGet("Get")]
    public async Task<Response<List<GetOrderItemDto>>> Gett()
    {
        return await _orderItemCervice.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddOrderItemDto>> Addd(AddOrderItemDto c)
    {
        if (ModelState.IsValid)
        {
            return await _orderItemCervice.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddOrderItemDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddOrderItemDto>> Updatee([FromBody] AddOrderItemDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _orderItemCervice.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddOrderItemDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    [HttpDelete("{id}")]
    public async Task<Response<GetOrderItemDto>> Deletee(int id)
    {
        return await _orderItemCervice.Delete(id);
    
    }

  
}

