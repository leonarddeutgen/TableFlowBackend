using WebApplication2.Data.Entities;

namespace WebApplication2.Data.Dtos;

public class CreateBillDto
{
    public int TableId { get; set; }
    public int OrganisationId { get; set; }
}