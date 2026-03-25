using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Data.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }

    public List<Product> Products { get; set; }
    public int OrganisationId { get; set; }
    public Organisation Organisation { get; set; }
}