using System.ComponentModel.DataAnnotations;

namespace TableFlow.Data.Entities;

public class BillItem
{
    [Key]
    public int BillItemId { get; set; }
    
    [Required]
    public int BillId { get; set; }
    public Bill? Bill { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public DateTime AddedAt { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Required]
    public int Quantity { get; set; }
}

