

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;
namespace Infrastructure.Services;


public class  OrderItemCervice
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public  OrderItemCervice(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetOrderItemDto>>> Get()
    {
        try
        {
            var result = await _context.OrderItems.ToListAsync();
            var mapped = _mapper.Map<List<GetOrderItemDto>>(result);
            return new Response<List<GetOrderItemDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetOrderItemDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    } public async Task<Response<AddOrderItemDto>> Add(AddOrderItemDto model)
    {
        try
        {
            var existingStudent =await _context.OrderItems.FirstOrDefaultAsync(x=>x.OrderId != model.OrderId && x.ProductId != model.ProductId);

            if (existingStudent != null)
            {
                return new Response<AddOrderItemDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Album with such data already exists" });
            }
            var mapped = _mapper.Map<OrderItem>(model);
            await _context.OrderItems.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddOrderItemDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddOrderItemDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    
    public async Task<Response<AddOrderItemDto>> Update(AddOrderItemDto model)
    {

        try
        {
          
           
            var update =await _context.OrderItems.Where(x=>x.OrderId != model.OrderId && x.ProductId == model.ProductId).AsNoTracking().FirstOrDefaultAsync();

            if ( update !=null)
            {
             
                var mapped = _mapper.Map<OrderItem>(model);
                _context.OrderItems.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddOrderItemDto>(model);
                
            }
            else
            {
                return new Response<AddOrderItemDto>(HttpStatusCode.BadRequest,new List<string>() { $" AlbumId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddOrderItemDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    
    public async Task<Response<GetOrderItemDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.OrderItems.Where(x=>x.OrderId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetOrderItemDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetOrderItemDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetOrderItemDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
    
}













 



