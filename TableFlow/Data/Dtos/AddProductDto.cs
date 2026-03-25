namespace TableFlow.Data.Dtos;

public class AddProductDto
{
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int CategoryId { get; set; }
    public int OrganisationId { get; set; }
}