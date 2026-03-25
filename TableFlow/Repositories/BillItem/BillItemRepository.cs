using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class BillItemsRepository : IBillItemsRepository
{
    private readonly AppDbContext _context;

    public BillItemsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Bill?> GetBillWithItemsAsync(int billId)
    {
        return await _context.Bills
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.BillId == billId);
    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task AddBillItemToBillAsync(int billId, BillItem billItem)
    {
        var bill = await GetBillWithItemsAsync(billId);
        bill.Items.Add(billItem);
    }

    public Task RemoveBillItemAsync(BillItem billItem)
    {
          _context.BillItems.Remove(billItem);
          return Task.CompletedTask;
    }
    
    public async Task<Bill?> GetBillByTableIdAsync(int tableId)
    {
        return await _context.Bills
            .Include(b=> b.Items)
            .FirstOrDefaultAsync(
                b => b.TableId == tableId
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