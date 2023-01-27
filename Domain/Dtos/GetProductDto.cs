﻿namespace Domain.Dtos;

public class GetProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int SupplierId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal  TotalAmount { get; set; }
    
    public GetProductDto()
    {
            
    }

    public GetProductDto(int productId,string productName,int supplierId,decimal totalAmount)
    {
        ProductId = productId;
        ProductName = productName;
        SupplierId = supplierId;
        OrderDate = DateTime.UtcNow;
        TotalAmount = totalAmount;
    }    
}