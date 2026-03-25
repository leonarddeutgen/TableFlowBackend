using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication2.Data.Dtos;
using Table = WebApplication2.Data.Entities.Table;

namespace WebApplication2.Services;

public interface ITableService
{
    Task<List<Table>> GetTablesAsync(int roomId);
    Task<Table?> GetTableAsync(int tableId);
    Task<Table> UpdateTablePosition(int tableId,UpdateTablePositionDto dto);
    Task<Table> CreateTableAsync(CreateTableDto dto);
}