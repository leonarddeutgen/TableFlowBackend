using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IUserService
{
    Task<User> LogInUser(LogInUserDto dto);
    Task<User?> GetUserById(int userId);
    Task<User> RegisterUser(CreateUserDto dto);
}