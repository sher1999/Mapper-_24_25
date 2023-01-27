using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class SuppierController:ControllerBase
{

    private readonly SupplierService _supplierService;
    

    public SuppierController(SupplierService productService)
    {
        _supplierService=productService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetSupplierDto>>> Gett()
    {
        return await _supplierService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddSupplierDto>> Addd(AddSupplierDto c)
    {
        if (ModelState.IsValid)
        {
            return await _supplierService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddSupplierDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddSupplierDto>> Updatee([FromBody] AddSupplierDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _supplierService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddSupplierDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    [HttpDelete("{id}")]
    public async Task<Response<GetSupplierDto>> Deletee(int id)
    {
        return await _supplierService.Delete(id);
    
    }

}

