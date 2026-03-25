using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public interface IBillItemsRepository
{
    Task<Bill?> GetBillWithItemsAsync(int billId);
    Task<Product> GetProductAsync(int productId);
    Task RemoveBillItemAsync(BillItem billItem);
    Task<Bill?> GetBillByTableIdAsync(int tableId);
    
    Task AddBillAsync(Bill bill);
    Task SaveChangesAsync();
}