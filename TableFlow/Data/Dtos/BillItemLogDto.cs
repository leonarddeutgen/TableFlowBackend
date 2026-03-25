using TableFlow.Data.Entities;

namespace TableFlow.Data.Dtos;

public class BillItemLogDto
{
    public string ProductName { get; set; } = string.Empty;
    public int QuantityChange { get; set; }
    public decimal? UnitPrice { get; set; }
    public BillItemLogAction Action { get; set; }
    public DateTime? CreatedAt { get; set; }
}
