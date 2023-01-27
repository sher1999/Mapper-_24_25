
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;
namespace Infrastructure.Services;


public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetProductDto>>> Get()
    {
        try
        {
            var result = await _context.Products.ToListAsync();
            var mapped = _mapper.Map<List<GetProductDto>>(result);
            return new Response<List<GetProductDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetProductDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    } public async Task<Response<AddProductDto>> Add(AddProductDto model)
    {
        try
        {
            var existingStudent =await _context.Products.FirstOrDefaultAsync(x=>x.ProductId != model.ProductId && x.SupplierId != model.SupplierId);

            if (existingStudent != null)
            {
                return new Response<AddProductDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Album with such data already exists" });
            }
            var mapped = _mapper.Map<Product>(model);
            await _context.Products.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddProductDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddProductDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    
    public async Task<Response<AddProductDto>> Update(AddProductDto model)
    {

        try
        {
          
           
            var update =await _context.Products.Where(x=>x.ProductId != model.ProductId && x.SupplierId != model.SupplierId).AsNoTracking().FirstOrDefaultAsync();

            if ( update !=null)
            {
             
                var mapped = _mapper.Map<Product>(model);
                _context.Products.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddProductDto>(model);
                
            }
            else
            {
                return new Response<AddProductDto>(HttpStatusCode.BadRequest,new List<string>() { $" AlbumId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddProductDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    
    public async Task<Response<GetProductDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.Products.Where(x=>x.ProductId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetProductDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetProductDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetProductDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
    
}










