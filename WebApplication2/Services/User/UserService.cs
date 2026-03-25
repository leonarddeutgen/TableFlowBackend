using Microsoft.AspNetCore.Identity;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPermissionModelRepository _permissionModelRepository;

    public UserService(IUserRepository userRepository, IPermissionModelRepository permissionModelRepository)
    {
        _userRepository = userRepository;
        _permissionModelRepository = permissionModelRepository;
    }
    
    public async Task<User> LogInUser(LogInUserDto dto)
    {
        var user = await _userRepository.GetUserAsync(dto.Email);
        if (user == null)
        {
            throw new ApplicationException("Invalid credentials");
        }
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.UserPassword, dto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new ApplicationException("Invalid credentials");
        }
        
        return user;
    }

    public Task<User?> GetUserById(int userId)
    {
        var user = _userRepository.GetUserById(userId);
        if (user == null)
        {
            throw new ApplicationException("Invalid credentials");
        }

        return user;
    }

    public async Task<User> RegisterUser(CreateUserDto dto)
    {
        var existingUser = await _userRepository.GetUserAsync(dto.UserEmail);
        if (existingUser != null)
        {
            throw new ApplicationException("User already exists");
        }
        
        var permissionModel = await _permissionModelRepository.GetPermissionModelByIdAsync(dto.PermissionId);
        if (permissionModel == null)
        {
            throw new ApplicationException("Invalid permission");
        }
        var user = new User()
        {
            UserName = dto.UserName,
            UserEmail = dto.UserEmail.ToLower(),
            PermissionId = dto.PermissionId
        };
        
        var hasher = new PasswordHasher<User>();
        user.UserPassword = hasher.HashPassword(user, dto.UserPassword);
        
        await _userRepository.AddUser(user);
        await _userRepository.SaveChangesAsync();
        return user;
    }
}