using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data.Entities;

public class Room
{
    [Key]
    public int RoomId { get; set; }

    [StringLength(50)]
    [Required]
    public string RoomName { get; set; }

    public List<Table> Tables { get; set; }
    
    public int OrganisationId {get; set;}
    public  Organisation Organisation {get; set;}
}
