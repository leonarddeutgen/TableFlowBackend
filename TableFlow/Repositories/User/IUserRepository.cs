using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserAsync(string email);
    Task<User?> GetUserById(int userId);
    Task<User> AddUser(User user);
    Task SaveChangesAsync();
}