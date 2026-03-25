using System.ComponentModel.DataAnnotations;

namespace TableFlow.Data.Entities;

public class Bill
{
    [Key]
    public int BillId { get; set; }

    public Decimal TotalAmount { get; set; } = 0;
    
    public BillStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public List<BillItem>? Items { get; set; } = new();
    
    public int? TableId { get; set; }
    public Table? Table { get; set; }
    
    [Required]
    public int OrganisationId { get; set; }
    public Organisation Organisation { get; set; }
    public void RecalculateTotal()
    {
        TotalAmount = Items.Sum(i => i.UnitPrice * i.Quantity);
    }
    
    public void Cancel()
    {
        if (Status != BillStatus.Open)
            throw new InvalidOperationException("Only open bills can be cancelled");

        Status = BillStatus.Cancelled;
        ClosedAt = DateTime.UtcNow;
    }

}
