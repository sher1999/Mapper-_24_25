using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class ProductController:ControllerBase
{

    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService=productService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetProductDto>>> Gett()
    {
        return await _productService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddProductDto>> Addd(AddProductDto c)
    {
        if (ModelState.IsValid)
        {
            return await _productService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddProductDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddProductDto>> Updatee([FromBody] AddProductDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _productService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddProductDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    [HttpDelete("{id}")]
    public async Task<Response<GetProductDto>> Deletee(int id)
    {
        return await _productService.Delete(id);
    
    }

}

