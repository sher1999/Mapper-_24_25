using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;
namespace Infrastructure.Services;

public class SupplierService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SupplierService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

  
    public async Task<Response<List<GetSupplierDto>>> Get()
    {
        try
        {
            var result = await _context.Suppliers.ToListAsync();
            var mapped = _mapper.Map<List<GetSupplierDto>>(result);
            return new Response<List<GetSupplierDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetSupplierDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    } public async Task<Response<AddSupplierDto>> Add(AddSupplierDto model)
    {
        try
        {
            var existingStudent = _context.Suppliers.Where(x => x.SupplierId == model.SupplierId).FirstOrDefault();
            if (existingStudent != null)
            {
                return new Response<AddSupplierDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Album with such data already exists" });
            }
            var mapped = _mapper.Map<Supplier>(model);
            await _context.Suppliers.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddSupplierDto>(model);
        }
        catch (Exception e)
        {
            return  new Response<AddSupplierDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    
    public async Task<Response<AddSupplierDto>> Update(AddSupplierDto model)
    {

        try
        {
          
           
            var update =await _context.Suppliers.Where(x => x.SupplierId == model.SupplierId).AsNoTracking().FirstOrDefaultAsync();

            if ( update !=null)
            {
             
                var mapped = _mapper.Map<Supplier>(model);
                _context.Suppliers.Update(mapped);
                await _context.SaveChangesAsync();
                return new Response<AddSupplierDto>(model);
                
            }
            else
            {
                return new Response<AddSupplierDto>(HttpStatusCode.BadRequest,new List<string>() { $" AlbumId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddSupplierDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    
    public async Task<Response<GetSupplierDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.Suppliers.Where(x=>x.SupplierId == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetSupplierDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetSupplierDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetSupplierDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}


