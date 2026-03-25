using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class TableRepository : ITableRepository
{
    private readonly AppDbContext _context;

    public TableRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Table> GetTableByIdAsync(int tableId)
    {
        var table = await _context.Tables.SingleOrDefaultAsync(t => t.TableId == tableId);
        return table;
    }

    public async Task<List<Table>> GetTablesForRoomAsync(int roomId)
    {
        var tables = _context.Tables
            .Where(t => t.RoomId == roomId)
            .Include(t => t.Bills.Where(b => b.Status == BillStatus.Open))
            .ToList();
        return tables;
    }

    public Task<Table> UpdateTablePosition(UpdateTablePositionDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<Table> GetTableByNameAndOrgId(string tableName, int orgId)
    {
        var table = _context.Tables.SingleOrDefault(t => t.TableName == tableName 
                                                         && t.OrganisationId == orgId);
        return table;
    }

    public Task AddTable(Table table)
    {
        _context.Tables.Add(table);
        return Task.CompletedTask;
    }
    
    public Task SaveChanges()
    {
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}