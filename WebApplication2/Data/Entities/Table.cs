using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data.Entities;

public class Table
{
    [Key]
    public int TableId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string TableName { get; set; }
    [Required]
    public double PositionX { get; set; }
    [Required]
    public double PositionY { get; set; }
    public int RoomId { get; set; }
    
    [Required]
    public int OrganisationId { get; set; }
    public Room Room { get; set; }
    public List<Bill> Bills { get; set; }
}