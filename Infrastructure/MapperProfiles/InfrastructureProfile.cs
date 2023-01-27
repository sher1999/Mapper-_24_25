using AutoMapper;
using Domain.Entities;
using Domain.Dtos;

namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Address, GetAddressDto>().ReverseMap();
        CreateMap<AddAddressDto, Address>().ReverseMap();

        CreateMap<Customer, GetCustomerDto>().ReverseMap();
        CreateMap<AddAddressDto, Customer>().ReverseMap();
        
        CreateMap<Album, GetAlbumDto>().ReverseMap();
        CreateMap<AddAddressDto, Album>().ReverseMap();
        
        CreateMap<Order, GetOrderDto>().ReverseMap();
        CreateMap<AddOrderDto, Order>().ReverseMap();
        
        CreateMap<OrderItem, GetOrderItemDto>().ReverseMap();
        CreateMap<AddOrderItemDto, OrderItem>().ReverseMap();
        
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<AddProductDto, Product>().ReverseMap();
        
        CreateMap<Supplier, GetSupplierDto>().ReverseMap();
        CreateMap<AddSupplierDto, Supplier>().ReverseMap();
      
    }
}