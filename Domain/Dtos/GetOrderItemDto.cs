namespace Domain.Dtos;

public class GetOrderItemDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitRrice { get; set; }
    public int Quantity { get; set; }

    public GetOrderItemDto()
    {
        
    }

    public GetOrderItemDto(int orderId,int productId,decimal unitRrice,int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        UnitRrice = unitRrice;
        Quantity = quantity;
    }
}