using AutoMapper;
using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Wrapper;
namespace Infrastructure.Services;
using Domain.Wrapper;
public class CustomerService
{
    private readonly DataContext _context;

    private readonly IMapper _mapper;

    public CustomerService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetCustomerDto>>> Get()
    {
        try
        {
            var result = await _context.Customers.ToListAsync();
            var mapped = _mapper.Map<List<GetCustomerDto>>(result);
            return new Response<List<GetCustomerDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetCustomerDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddCustomerDto>> Add(AddCustomerDto model)
    {
        try
        {
            var existingStudent = _context.Customers.Where(x => x.CustomerId == model.CustomerId).FirstOrDefault();
            if (existingStudent != null)
            {
                return new Response<AddCustomerDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Customer with such data already exists" });
            }
            var mapped = _mapper.Map<Customer>(model);
            await _context.Customers.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddCustomerDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddCustomerDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    
    public async Task<Response<AddCustomerDto>> Update(AddCustomerDto model)
    {

        try
        {
          
           
            var update =await _context.Customers.Where(x => x.CustomerId == model.CustomerId).AsNoTracking().FirstOrDefaultAsync();

            if ( update !=null)
            {
             
                var mapped = _mapper.Map<Customer>(model);
                _context.Customers.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddCustomerDto>(model);
                
            }
            else
            {
                return new Response<AddCustomerDto>(HttpStatusCode.BadRequest,new List<string>() { $" CostomerId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddCustomerDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    
    public async Task<Response<GetAddressDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.Customers.Where(x=>x.CustomerId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetAddressDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetAddressDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetAddressDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}











