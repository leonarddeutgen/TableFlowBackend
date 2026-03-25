using WebApplication2.Data.Entities;

namespace WebApplication2.Data.Dtos;

public class BillItemLogDto
{
    public string ProductName { get; set; } = string.Empty;
    public int QuantityChange { get; set; }
    public decimal? UnitPrice { get; set; }
    public BillItemLogAction Action { get; set; }
    public DateTime? CreatedAt { get; set; }
}
