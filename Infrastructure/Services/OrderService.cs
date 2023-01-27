
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;
namespace Infrastructure.Services;


public class OrderService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public OrderService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetOrderDto>>> Get()
    {
        try
        {
            var result = await _context.Orders.ToListAsync();
            var mapped = _mapper.Map<List<GetOrderDto>>(result);
            return new Response<List<GetOrderDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetOrderDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    } public async Task<Response<AddOrderDto>> Add(AddOrderDto model)
    {
        try
        {
            var existingStudent =await _context.Orders.FirstOrDefaultAsync(x=>x.OrderId != model.OrderId && x.CustomerId != model.CustomerId);

            if (existingStudent != null)
            {
                return new Response<AddOrderDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Album with such data already exists" });
            }
            var mapped = _mapper.Map<Order>(model);
            await _context.Orders.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddOrderDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddOrderDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    
    public async Task<Response<AddOrderDto>> Update(AddOrderDto model)
    {

        try
        {
          
           
            var update =await _context.Orders.Where(x=>x.OrderId != model.OrderId && x.CustomerId == model.CustomerId).AsNoTracking().FirstOrDefaultAsync();

            if ( update !=null)
            {
             
                var mapped = _mapper.Map<Order>(model);
                _context.Orders.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddOrderDto>(model);
                
            }
            else
            {
                return new Response<AddOrderDto>(HttpStatusCode.BadRequest,new List<string>() { $" AlbumId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddOrderDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    
    public async Task<Response<GetOrderDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.Orders.Where(x=>x.OrderId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetOrderDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetOrderDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetOrderDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
    
}













 