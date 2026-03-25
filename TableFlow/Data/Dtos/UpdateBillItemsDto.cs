using TableFlow.Data.Entities;

namespace TableFlow.Data.Dtos;
public class MoveBillItemDto
{
    public int BillItemId { get; set; }
    public int Quantity { get; set; }
}

public class MoveBillItemsDto
{
    public int SourceTableId { get; set; }
    public int TargetTableId { get; set; }
    public List<MoveBillItemDto> Items { get; set; }
}

