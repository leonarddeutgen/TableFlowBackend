using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillItemsController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IBillItemsService _billItemsService;

    public BillItemsController(
        AppDbContext dbContext,
        IBillItemsService billItemsService
        )
    {
        _dbContext = dbContext;
        _billItemsService = billItemsService;
    }
    // UPDATE BILLITEMS
    [HttpPost]
    public async Task<IActionResult> AddBillItems([FromBody] AddBillItemsDto dto)
    {
        try
        {
            var bill = await _billItemsService.AddBillItemsAsync(dto);
            return Ok(bill);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
 
    }
    
    [HttpPut]
    public async Task<IActionResult> MovePartialBillItems([FromBody] MoveBillItemsDto dto) 
    {
        try
        {
            var result = await _billItemsService.MovePartialBillItems(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("target")]
    public async Task<IActionResult> MoveWholeBill([FromBody] MoveWholeBillDto dto)
    {
        try
        {
            var result = await _billItemsService.MoveWholeBill(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
