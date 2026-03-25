using TableFlow.Data.Entities;

namespace TableFlow.Data.Dtos;

public class CreateBillDto
{
    public int TableId { get; set; }
    public int OrganisationId { get; set; }
}