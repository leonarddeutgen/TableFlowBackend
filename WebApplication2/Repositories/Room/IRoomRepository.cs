using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface IRoomRepository
{
    Task<List<Room>> GetAllRoomsAsync(int orgId);
    Task<Room?> GetRoomByIdAsync(int roomId);
    Task<Room?> GetRoomByNameAndId(string roomName, int orgId);
    Task AddRoom(Room room);
    Task RemoveRoomById(int roomId);
    Task SaveChangesAsync();
}