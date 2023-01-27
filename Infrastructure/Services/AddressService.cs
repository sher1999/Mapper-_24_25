using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class AddressService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AddressService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetAddressDto>>> Get()
    {
        try
        {
            var result = await _context.Addresses.ToListAsync();
            var mapped = _mapper.Map<List<GetAddressDto>>(result);
            return new Response<List<GetAddressDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetAddressDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddAddressDto>> Add(AddAddressDto model)
    {
        try
        {
            var existingStudent =await _context.Addresses.FirstOrDefaultAsync(x=>x.CustomerId != model.CustomerId && x.AddressId != model.AddressId);
            if (existingStudent != null)
            {
                return new Response<AddAddressDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Customer with such data already exists" });
            }
            var mapped = _mapper.Map<Address>(model);
            await _context.Addresses.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddAddressDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddAddressDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddAddressDto>> Update(AddAddressDto model)
    {

        try
        {
          
            var update =await _context.Addresses.Where(x=>x.CustomerId != model.CustomerId && x.AddressId == model.AddressId).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<Address>(model);
                _context.Addresses.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddAddressDto>(model);
               
               
            }
            else
            {
                return new Response<AddAddressDto>(HttpStatusCode.BadRequest,new List<string>() { $"AddressId ili CostomerId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddAddressDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetAddressDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.Addresses.Where(x=>x.AddressId == id).FirstOrDefaultAsync();
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