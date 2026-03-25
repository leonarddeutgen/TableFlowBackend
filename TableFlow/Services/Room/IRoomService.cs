using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IRoomService
{
    Task<List<Room>> GetAllRoomsAsync(int orgId);
    Task<Room?> GetRoomByIdAsync(int roomId);
    Task<Room> CreateRoomAsync(CreateRoomDto dto);
    Task<Room> DeleteRoomAsync(int roomId);
}