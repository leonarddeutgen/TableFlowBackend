using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [StringLength(50)]
    [Required]
    public string ProductName { get; set; }

    [Required]
    public decimal ProductPrice { get; set; }
    
    [Required]
    public bool IsActive { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
    
    [Required]
    public int OrganisationId { get; set; }
}
