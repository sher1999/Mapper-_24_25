using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    [Required,MaxLength(20)]
    public  string OrderNumber { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal  TotalAmount { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    public Order()
    {
        
    }

    public Order(int orderId,string orderNumber,int customerId,decimal totalAmount)
    {
        OrderId = orderId;
        OrderNumber = orderNumber;
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        TotalAmount = totalAmount;  
    }
}
