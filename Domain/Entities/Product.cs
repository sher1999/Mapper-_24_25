using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Product
{ [Key]
    public int ProductId { get; set; }
    [Required,MaxLength(50)]
    public string ProductName { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal  TotalAmount { get; set; }
    public  List<OrderItem> OrderItems { get; set; }
    public List<Album> Albums { get; set; } = new();

    public Product()
    {
            
    }

    public Product(int productId,string productName,int supplierId,decimal totalAmount)
    {
        ProductId = productId;
        ProductName = productName;
        SupplierId = supplierId;
        OrderDate = DateTime.UtcNow;
        TotalAmount = totalAmount;
    }    
}