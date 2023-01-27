namespace Domain.Dtos;

public class GetOrderDto
{
   
    public int OrderId { get; set; }
    public  string OrderNumber { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal  TotalAmount { get; set; }

    public GetOrderDto()
    {
        
    }

    public GetOrderDto(int orderId,string orderNumber,int customerId,decimal totalAmount)
    {
        OrderId = orderId;
        OrderNumber = orderNumber;
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        TotalAmount = totalAmount;  
    }
}