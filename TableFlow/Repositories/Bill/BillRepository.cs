using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class BillRepository : IBillRepository
{
    private readonly AppDbContext _context;
    public BillRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Bill?> GetBillAsync(int tableId)
    {
       return await _context.Bills
            .Include(b=> b.Items)
            .ThenInclude(b=> b.Product)
            .FirstOrDefaultAsync(b=> b.TableId == tableId
                                     && b.Status == BillStatus.Open);
    }
    public async Task<Bill?> GetOpenBillByTableAsync(int tableId)
    {
        return await _context.Bills
            .FirstOrDefaultAsync(b => b.TableId == tableId && b.Status == BillStatus.Open);
    }
    public async Task<Bill?> GetOpenBillByIdAsync(int billId)
    {
       return await _context.Bills
           .FirstOrDefaultAsync(b => b.BillId == billId 
                                     && b.Status == BillStatus.Open);
    }
    public Task AddBillAsync(Bill bill)
    {
        _context.Bills.Add(bill);
        return Task.CompletedTask;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}