using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillItemLogController : ControllerBase
{
    private readonly IBillItemLogService _service;

    public BillItemLogController(IBillItemLogService service)
    {
        _service = service;
    }
    
    // GET
    [HttpGet("{billId:int}")]
    public async Task<IActionResult> GetBillItemLog(int billId)
    {
        try
        {
            var logs = await _service.GetBillLogAsync(billId);
            return Ok(logs);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}