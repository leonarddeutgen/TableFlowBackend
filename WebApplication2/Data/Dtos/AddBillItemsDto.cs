using WebApplication2.Data.Entities;

namespace WebApplication2.Data.Dtos;

public class AddBillItemEntryDto
{
    public int ProductId { get; set; }
    public int Quantity{ get; set; }
}

public class AddBillItemsDto
{
    public int BillId { get; set; }
    public List<AddBillItemEntryDto> BillItems { get; set; }
}