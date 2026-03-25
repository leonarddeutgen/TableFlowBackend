using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IRoomService
{
    Task<List<Room>> GetAllRoomsAsync(int orgId);
    Task<Room?> GetRoomByIdAsync(int roomId);
    Task<Room> CreateRoomAsync(CreateRoomDto dto);
    Task<Room> DeleteRoomAsync(int roomId);
}