using Domain.Entities;  
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
namespace WepApi.Controllers;


[Route("[controller]")]

public class AddressController : ControllerBase
{

    private readonly AddressService _addressService;

    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetAddressDto>>> Gett()
    {
        return await _addressService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddAddressDto>> Addd(AddAddressDto c)
    {
        if (ModelState.IsValid)
        {
            return await _addressService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddAddressDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddAddressDto>> Updatee([FromBody] AddAddressDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _addressService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddAddressDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetAddressDto>>  Deletee(int id)
    {
       return await _addressService.Delete(id);
    
}

}




