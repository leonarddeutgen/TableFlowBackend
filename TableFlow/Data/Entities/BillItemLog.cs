using System.ComponentModel.DataAnnotations;

namespace TableFlow.Data.Entities;

public class BillItemLog
{
    [Key]
    public int BillItemLogId { get; set; }
    
    [Required]
    public int BillId { get; set; }
    public Bill Bill { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    [Required]
    public int QuantityChange { get; set; }
    
    public decimal? UnitPrice { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    [Required]
    public BillItemLogAction Action { get; set; }
}