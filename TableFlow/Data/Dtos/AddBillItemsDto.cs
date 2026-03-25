using TableFlow.Data.Entities;

namespace TableFlow.Data.Dtos;

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