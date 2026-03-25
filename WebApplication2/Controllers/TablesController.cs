using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesController : ControllerBase
{
    private readonly ITableService _service;

    public TablesController(ITableService service)
    {
        _service = service;
    }
    
    [HttpGet("single/{tableId:int}")]
    public async Task<IActionResult> GetSingleTable(int tableId)
    {
        var table = await _service.GetTableAsync(tableId);
        return Ok(table);
    }
    
    [HttpGet("{roomId:int}")]
    public async Task<IActionResult> GetTables(int roomId)
    {
        var tables = await _service.GetTablesAsync(roomId);
        return Ok(tables);
    }
    
    [HttpPut]
    [Route("{tableId:int}")]
    public async Task<IActionResult> UpdateTablePosition(int tableId, [FromBody] UpdateTablePositionDto dto)
    {
        var table = await _service.UpdateTablePosition(tableId, dto);
        return Ok(table);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewTable([FromBody] CreateTableDto dto)
    {
        var table = await _service.CreateTableAsync(dto);
        return Ok(table);
    }
    
    
    
}