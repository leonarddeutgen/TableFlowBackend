using System.ComponentModel.DataAnnotations;

namespace TableFlow.Data.Dtos;

public class CreateUserDto
{
    public string? UserName { get; set; }

    [Required] public string UserEmail { get; set; }

    [Required] public string UserPassword { get; set; }

    [Required]
    public int PermissionId { get; set; }
}
