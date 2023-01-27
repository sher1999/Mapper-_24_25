namespace Domain.Dtos;

public class GetAddressDto
{
    public int AddressId { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public  string City { get; set; }
    public  int PostalCode { get; set; }
    public int CustomerId { get; set; }

    public GetAddressDto()
    {
            
    }

    public GetAddressDto(int addressId,string address1,string address2,string city,int postalCode,int customerId)
    {
        AddressId = addressId;
        Address1 = address1;
        Address2 = address2;
        City = city;
        PostalCode = postalCode;
        CustomerId = customerId;
    }
}