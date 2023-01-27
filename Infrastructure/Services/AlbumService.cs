
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;
namespace Infrastructure.Services;


public class AlbumService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AlbumService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetAlbumDto>>> Get()
    {
        try
        {
            var result = await _context.Albums.ToListAsync();
            var mapped = _mapper.Map<List<GetAlbumDto>>(result);
            return new Response<List<GetAlbumDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetAlbumDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    } public async Task<Response<AddAlbumDto>> Add(AddAlbumDto model)
    {
        try
        {
            var existingStudent =await _context.Albums.FirstOrDefaultAsync(x=>x.AlbumId != model.AlbumId && x.ProductId != model.ProductId);

            if (existingStudent != null)
            {
                return new Response<AddAlbumDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Album with such data already exists" });
            }
            var mapped = _mapper.Map<Album>(model);
            await _context.Albums.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddAlbumDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddAlbumDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    
    public async Task<Response<AddAlbumDto>> Update(AddAlbumDto model)
    {

        try
        {
          
           
            var update =await _context.Albums.Where(x=>x.AlbumId != model.AlbumId && x.ProductId == model.ProductId).AsNoTracking().FirstOrDefaultAsync();

            if ( update !=null)
            {
             
                var mapped = _mapper.Map<Album>(model);
                _context.Albums.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddAlbumDto>(model);
                
            }
            else
            {
                return new Response<AddAlbumDto>(HttpStatusCode.BadRequest,new List<string>() { $" AlbumId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddAlbumDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    
    public async Task<Response<GetAlbumDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.Albums.Where(x=>x.AlbumId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetAlbumDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetAlbumDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetAlbumDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
    
}







