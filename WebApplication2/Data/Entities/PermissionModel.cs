using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Data.Entities;

public class PermissionModel
{
    [Key]
    public int PermissionId { get; set; }
    
    [Required]
    public string PermissionName { get; set; }
    
    public string? PermissionDescription { get; set; }
    
    public string? PermissionText { get; set; }
    
    public int? MaxOrganisations { get; set; }
    
    public int? MaxRooms { get; set; }
    
    public int PermissionPrice { get; set; }

    public List<User> Users { get; set; }
}