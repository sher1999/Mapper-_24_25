namespace Domain.Entities;

public class OrderItem
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public  Product Product { get; set; }
    public decimal UnitRrice { get; set; }
    public int Quantity { get; set; }

    public OrderItem()
    {
        
    }

    public OrderItem(int orderId,int productId,decimal unitRrice,int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        UnitRrice = unitRrice;
        Quantity = quantity;
    }
}