using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;


public class Customer
{
  

    [Key]
    public  int CustomerId { get; set; }
    [Required,MaxLength(50)]
    public string FirsName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required,MaxLength(50)]
    public string PhoneNumber { get; set; }
    [Required,MaxLength(50)]
    public string Email { get; set; }
    public Address Addresses { get; set; }
    public List<Order> Orders { get; set; } = new();
    public Customer()
    {
            
    }

    public Customer(int customerId, string firsName, string lastName, string phoneNumber, string email)
    {
        CustomerId = customerId;
        FirsName = firsName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    } 
}
