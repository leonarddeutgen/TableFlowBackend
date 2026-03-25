using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganisationsController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IOrganisationService _organisationService;
    
    public OrganisationsController(AppDbContext dbContext, IOrganisationService organisationService)
    {
        _dbContext = dbContext;
        _organisationService = organisationService;
    }
    
    // GET ORGANISATION BY ID
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrganisationById(int id)
    {
        var org = await _organisationService.GetOrganisationByIdAsync(id);
        return Ok(org);
    }
    
    //GET ALL ORGANISATIONS FOR USER 
    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<List<Organisation>>> GetOrganisationsByUserId(int userId)
    {
        var organisations = await _organisationService.GetAllOrganisationsByUserIdAsync(userId);
        return Ok(organisations);
    }
    
    // CREATE ORGANISATION
    [HttpPost]
    public async Task<IActionResult> AddOrganisation([FromBody] CreateOrganisationDto dto)
    {
        var org = await _organisationService.CreateOrganisationAsync(dto);
        return Ok(org);
    }
    
    // GET DAILY SALES
    [HttpGet("sales/{id:int}")]
    public async Task<IActionResult> GetDailySales(
        int id,
        DateTime from,
        DateTime to)
    {
        var total = await _dbContext.Bills
            .Where(b =>
                b.OrganisationId == id &&
                b.Status == BillStatus.Paid &&
                b.ClosedAt >= from &&
                b.ClosedAt <= to)
            .SumAsync(b => b.TotalAmount);

        return Ok(total);
    }
}