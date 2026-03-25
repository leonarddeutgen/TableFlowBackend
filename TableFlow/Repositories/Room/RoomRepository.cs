using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<List<Room>> GetAllRoomsAsync(int orgId)
    {
        var allRooms = _context.Rooms
            .Where(r => r.OrganisationId == orgId)
            .Include(r => r.Tables).ToList();
        return Task.FromResult(allRooms);
    }

    public Task<Room?> GetRoomByIdAsync(int roomId)
    {
        var roomIncludingTables = _context.Rooms
            .Include(r => r.Tables)
            .FirstOrDefault(r => r.RoomId == roomId);
        return Task.FromResult(roomIncludingTables);
    }

    public Task<Room?> GetRoomByNameAndId(string roomName, int orgId)
    {
        var room = _context.Rooms
            .Where(r => r.RoomName == roomName 
                        && r.OrganisationId == orgId).FirstOrDefault();
        return Task.FromResult(room);
    }

    public Task AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        return Task.CompletedTask;
    }

    public Task RemoveRoomById(int roomId)
    {
        var room = _context.Rooms.SingleOrDefaultAsync(r => r.RoomId == roomId);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}