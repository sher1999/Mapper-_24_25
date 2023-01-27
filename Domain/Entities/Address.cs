using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Address
{ 
   [Key]
    public  int AddressId { get; set; }
    [Required,MaxLength(50)]
    public string Address1 { get; set; }
    [Required,MaxLength(50)]
    public string Address2 { get; set; }
    [Required,MaxLength(50)]
    public  string City { get; set; }
    public  int PostalCode { get; set; }
    public int CustomerId { get; set; }
    public  Customer Customer { get; set;  }

    public Address()
    {
            
    }

    public Address(int addressId,string address1,string address2,string city,int postalCode,int customerId)
    {
        AddressId = addressId;
        Address1 = address1;
        Address2 = address2;
        City = city;
        PostalCode = postalCode;
        CustomerId = customerId;
    }
}