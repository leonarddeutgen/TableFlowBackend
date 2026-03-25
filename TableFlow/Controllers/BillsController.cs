using Microsoft.AspNetCore.Mvc;
using TableFlow.Data.Dtos;
using TableFlow.Exceptions;
using TableFlow.Services;

namespace TableFlow.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillsController : Controller
{
    private readonly IBillService _billService;
    public BillsController(IBillService billService)
    {
        _billService = billService;
    }
    
    // GET BILL
    [HttpGet]
    [Route("{tableId:int}")]
    public async Task<IActionResult> GetActiveBill(int tableId)
    {
        try
        {
            var activeBill = await _billService.GetActiveBill(tableId);
            return Ok(activeBill);
        }
        catch (Exception e)
        {
            return NotFound(new { Message = e.Message });
        }
    }
    
    // CREATE BILL
    [HttpPost]
    public async Task<IActionResult> CreateNewBill([FromBody] CreateBillDto dto)
    {
        try
        {
            var newBill =  await _billService.CreateNewBill(dto);
            return Ok(newBill);
        }
        catch (BillAlreadyExistsException e)
        {
            return Conflict(new { message = e.Message });
        }
    }
    
    // CLOSE BILL
    [HttpPut("{billId:int}")]
    public async Task<IActionResult> CloseBill(int billId)
    {
        try
        {
            var billToRemove = await _billService.CloseBillById( billId);
            return Ok(billToRemove);
        }
        catch (NoActiveBill e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}



