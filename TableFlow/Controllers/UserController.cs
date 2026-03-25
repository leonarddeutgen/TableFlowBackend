using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;
using TableFlow.Services;

namespace TableFlow.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IUserService _userService;
    public UserController(AppDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }
    //LOG IN USER
    [HttpPost("login")]
    public async Task<IActionResult> LogInUser([FromBody] LogInUserDto dto)
    {
        var user = await _userService.LogInUser(dto);
        return Ok(user);
    }
    
    
    // GET USER
    [HttpGet]
    [Route("{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserById(userId);
        return Ok(user);
    }
    
    //GET ALL USERS
    [HttpGet]
    public IActionResult GetUsers()
    {
        try
        {
            List<User> users = _dbContext.Users.ToList();
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // REGISTER NEW USER
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody]CreateUserDto dto)
    {
        var user = await _userService.RegisterUser(dto);
        return Ok(user);
    }
}











