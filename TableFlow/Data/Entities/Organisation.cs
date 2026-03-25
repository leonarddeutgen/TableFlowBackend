using System.ComponentModel.DataAnnotations;

namespace TableFlow.Data.Entities;

public class Organisation
{
    [Key]
    public int OrganisationId { get; set; }
    [Required]
    public string OrganisationName { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<Room>? Rooms { get; set; }
    public List<Product>? Products { get; set; }
    public List<Category>? Categories { get; set; }
}


