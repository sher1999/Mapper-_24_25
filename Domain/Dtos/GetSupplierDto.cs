namespace Domain.Dtos;

public class GetSupplierDto
{
     public int SupplierId { get; set; }
     public string CompanyName { get; set; }
    public string Phone { get; set; }
 

    public GetSupplierDto()
    {
            
    }

    public GetSupplierDto(int supplierId , string companyName ,string phone)
    {
        SupplierId = supplierId;
        CompanyName = companyName;
        Phone = phone;
    }
}