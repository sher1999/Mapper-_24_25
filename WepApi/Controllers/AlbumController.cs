using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class AlbumController:ControllerBase
{

    private readonly AlbumService _albumService;

    public AlbumController(AlbumService albumService)
    {
        _albumService=albumService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetAlbumDto>>> Gett()
    {
        return await _albumService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddAlbumDto>> Addd(AddAlbumDto c)
    {
        if (ModelState.IsValid)
        {
            return await _albumService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddAlbumDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddAlbumDto>> Updatee([FromBody] AddAlbumDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _albumService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddAlbumDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    [HttpDelete("{id}")]
    public async Task<Response<GetAlbumDto>> Deletee(int id)
    {
        return await _albumService.Delete(id);
    
    }

  
}







