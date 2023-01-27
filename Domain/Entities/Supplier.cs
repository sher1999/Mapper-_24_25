using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Supplier
{
    [Key]
    public int SupplierId { get; set; }
    [Required,MaxLength(40)]
    public string CompanyName { get; set; }
    
    [Required,MaxLength(20)]
    public string Phone { get; set; }
    public List<Product> Products { get; set; }

    public Supplier()
    {
            
    }

    public Supplier(int supplierId , string companyName ,string phone)
    {
        SupplierId = supplierId;
        CompanyName = companyName;
        Phone = phone;
    }
}