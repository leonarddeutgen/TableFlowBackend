using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Dtos;
using TableFlow.Services;
using TableFlow.Data.Entities;

namespace TableFlow.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IRoomService _roomService;
    public RoomsController(AppDbContext dbContext, IRoomService roomService)
    {
        _dbContext = dbContext;
        _roomService = roomService;
    }
    // GET ROOMS BY ORGANISATION
    [HttpGet("organisation/{organisationId:int}")]
    public async Task<IActionResult> GetAllRooms(int organisationId)
    {
        var allRooms = await _roomService.GetAllRoomsAsync(organisationId);
        return Ok(allRooms);
    }

    //GET SINGLE ROOM
    [HttpGet]
    [Route("{roomId:int}")]
    public async Task<IActionResult> GetRoomById(int roomId)
    {
        var roomIncludingTables = await _roomService.GetRoomByIdAsync(roomId);

        return Ok(roomIncludingTables);
    }
    
    //CREATE ROOM
    [HttpPost]
    public async Task<IActionResult> CreateRoom(CreateRoomDto dto)
    { 
        var newRoom = await _roomService.CreateRoomAsync(dto);   
        return Ok(newRoom);
    }
    
    // DELETE ROOM
    [HttpDelete("{roomId:int}")]
    public async Task<IActionResult> DeleteRoom(int roomId)
    {
        await _roomService.DeleteRoomAsync(roomId);
        return Ok(new { message = "Room deleted successfully", roomId = roomId });
    }
}