using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserAsync(string email)
    {
        var user = await _context.Users
            .SingleOrDefaultAsync(u => u.UserEmail == email.ToLower());
        return user;
    }

    public async Task<User?> GetUserById(int userId)
    {
        var user = await _context.Users
            .Include(u=> u.Organisations)
            .Include(u=> u.PermissionModel)
            .FirstOrDefaultAsync(u=> u.UserId == userId);
        return user;
    }

    public Task<User> AddUser(User user)
    {
        _context.Users.Add(user);
        return Task.FromResult(user);
    }

    public Task SaveChangesAsync()
    {
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}