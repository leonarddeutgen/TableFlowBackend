using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TableFlow.Data.Dtos;
using TableFlow.Repositories;
using TableFlow.Data.Entities;
using Entities_Table = TableFlow.Data.Entities.Table;
using Table = TableFlow.Data.Entities.Table;

namespace TableFlow.Services;

public class TableService(ITableRepository tableRepository) : ITableService
{
    public async Task<List<Entities_Table>> GetTablesAsync(int roomId)
    {
        var tables = await tableRepository.GetTablesForRoomAsync(roomId);
        if (tables is null)
        {
            throw new ApplicationException($"No tables found for room {roomId}");
        }

        return tables;
    }

    public async Task<Entities_Table?> GetTableAsync(int tableId)
    {
        var table = await tableRepository.GetTableByIdAsync(tableId);
        if (table is null)
        {
            throw new ApplicationException($"No table found for table {tableId}");
        }

        return table;
    }

    public async Task<Entities_Table> UpdateTablePosition(int tableId, UpdateTablePositionDto dto)
    {
        var table = await tableRepository.GetTableByIdAsync(tableId);
        if (table is null)
        {
            throw new ApplicationException($"No table found for table {tableId}");
        }
        table.PositionX = dto.PositionX;
        table.PositionY = dto.PositionY;
       await tableRepository.SaveChanges();
       return table;
    }

    public async Task<Entities_Table> CreateTableAsync(CreateTableDto dto)
    {
        var existing = await tableRepository.GetTableByNameAndOrgId(dto.TableName, dto.OrganisationId);
        if (existing != null)
        {
            throw new ApplicationException($"Table with name {dto.TableName} already exists.");
        }
        
        var table = new Entities_Table
        {
            TableName = dto.TableName,
            RoomId = dto.RoomID,
            OrganisationId = dto.OrganisationId,
            PositionX = dto.PositionX,
            PositionY = dto.PositionY
        };
        
        await tableRepository.AddTable(table);
        await tableRepository.SaveChanges();
        return table;
    }
}