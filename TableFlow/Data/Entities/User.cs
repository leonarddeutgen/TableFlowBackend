using System.ComponentModel.DataAnnotations;
 
namespace TableFlow.Data.Entities;
public class User
{
    [Key]
    public int UserId { get; set; }
    
    [StringLength(50)]
    public string? UserName { get; set; }
    
    [Required]
    public string UserEmail { get; set; }
    
    [Required]
    public string UserPassword { get; set; }
    
    [Required]
    public int PermissionId { get; set; } 
    public PermissionModel? PermissionModel { get; set; }
    
    public List<Organisation>? Organisations { get; set; }
}