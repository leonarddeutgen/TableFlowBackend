using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IUserService
{
    Task<User> LogInUser(LogInUserDto dto);
    Task<User?> GetUserById(int userId);
    Task<User> RegisterUser(CreateUserDto dto);
}