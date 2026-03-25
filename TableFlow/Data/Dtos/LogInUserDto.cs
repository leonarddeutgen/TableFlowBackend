using System.ComponentModel.DataAnnotations;
namespace TableFlow.Data.Dtos;

public class LogInUserDto
{
    [Required] 
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

