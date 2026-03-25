using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TableFlow.Data.Dtos;
using Entities_Table = TableFlow.Data.Entities.Table;
using Table = TableFlow.Data.Entities.Table;

namespace TableFlow.Services;

public interface ITableService
{
    Task<List<Entities_Table>> GetTablesAsync(int roomId);
    Task<Entities_Table?> GetTableAsync(int tableId);
    Task<Entities_Table> UpdateTablePosition(int tableId,UpdateTablePositionDto dto);
    Task<Entities_Table> CreateTableAsync(CreateTableDto dto);
}