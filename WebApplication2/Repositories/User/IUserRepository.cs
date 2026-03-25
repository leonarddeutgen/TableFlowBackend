using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserAsync(string email);
    Task<User?> GetUserById(int userId);
    Task<User> AddUser(User user);
    Task SaveChangesAsync();
}