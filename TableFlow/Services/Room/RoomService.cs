using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;
using TableFlow.Repositories;

namespace TableFlow.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    
    public async Task<List<Room>> GetAllRoomsAsync(int orgId)
    {
        var rooms = await _roomRepository.GetAllRoomsAsync(orgId);

        if (rooms is null)
        {
            throw new ApplicationException($"Rooms not found for org {orgId}");
        }
        return rooms;
    }

    public async Task<Room?> GetRoomByIdAsync(int roomId)
    {
        var room = await _roomRepository.GetRoomByIdAsync(roomId);
        if (room is null)
        {
            throw new ApplicationException($"Room {roomId} not found");
        }
        return room;
    }

    public async Task<Room> CreateRoomAsync(CreateRoomDto dto)
    {
        var existingRoom = await _roomRepository.GetRoomByNameAndId(dto.Name, dto.OrgId);
        if (existingRoom != null)
        {
            throw new ApplicationException($"Room {dto.Name} already exists");
        }
        
        var newRoom = new Room
        {
            RoomName = dto.Name,
            OrganisationId = dto.OrgId
        };
        await _roomRepository.AddRoom(newRoom);
        await _roomRepository.SaveChangesAsync();
        return newRoom;
    }

    public async Task<Room> DeleteRoomAsync(int roomId)
    {
        var room = _roomRepository.GetRoomByIdAsync(roomId);

        if (room is null)
        {
            throw new ApplicationException($"Room {roomId} not found");
        }
        await _roomRepository.RemoveRoomById(roomId);
        await _roomRepository.SaveChangesAsync();
        return await room;
    }
}