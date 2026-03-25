using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public class BillItemLogRepository:IBillItemLogRepository
{
    private readonly AppDbContext _context;

    public BillItemLogRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<BillItemLogDto>> GetBillItemLogsAsync(int billId)
    {
        return await _context.BillItemLogs
            .Where(l => l.BillId == billId)
            .OrderByDescending(l => l.CreatedAt)
            .Select(l => new BillItemLogDto
            {
                ProductName = l.Product!.ProductName,
                QuantityChange = l.QuantityChange,
                UnitPrice = l.UnitPrice,
                Action = l.Action,
                CreatedAt = l.CreatedAt
            })
            .ToListAsync();
    }

    public async Task AddLogAsync(BillItemLog log)
    {
        await _context.BillItemLogs.AddAsync(log);
    }
}