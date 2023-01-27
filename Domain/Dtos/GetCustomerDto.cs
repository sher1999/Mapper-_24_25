using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class GetCustomerDto
{
    public  int CustomerId { get; set; }

    [Required,MaxLength(50)]
    public string FirsName { get; set; }

    public string LastName { get; set; }
  
    public string PhoneNumber { get; set; }
   
    public string Email { get; set; }
    public GetCustomerDto()
    {
            
    }

    public GetCustomerDto(int customerId, string firsName, string lastName, string phoneNumber, string email)
    {
        CustomerId = customerId;
        FirsName = firsName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    } 
}