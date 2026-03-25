using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface ITableRepository
{
    Task<Table> GetTableByIdAsync(int tableId);
    Task<List<Table>> GetTablesForRoomAsync(int roomId);
    Task<Table> UpdateTablePosition(UpdateTablePositionDto dto);
    Task<Table> GetTableByNameAndOrgId(string tableName, int orgId);
    Task SaveChanges();
    Task AddTable(Table table);
}