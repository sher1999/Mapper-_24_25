using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Wrapper;
using AutoMapper;
using System.Net;

namespace WepApi.Controllers;

[Route("[controller]")]

public class CustomerController:ControllerBase
{

    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService=customerService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetCustomerDto>>> Gett()
    {
        return await _customerService.Get();
    }
    
    
    [HttpPost("Add")]
    public async Task<Response<AddCustomerDto>> Addd([FromBody]AddCustomerDto c)
    {
        if (ModelState.IsValid)
        {
            return await _customerService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCustomerDto>(HttpStatusCode.BadRequest, errors);
        }
    }


    [HttpPut("Update")]
    public async Task<Response<AddCustomerDto>> Updatee([FromBody] AddCustomerDto c)
    {
        if (ModelState.IsValid)
        {
            return await _customerService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddCustomerDto>(HttpStatusCode.BadRequest, errors);
        } 
    }
    
    [HttpDelete("{id}")]
    public async Task<Response<GetAddressDto>> Deletee(int id) => await _customerService.Delete(id);

  
}


