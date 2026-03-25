using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public interface IBillRepository
{
    Task<Bill?> GetBillAsync(int tableId);
    Task<Bill?> GetOpenBillByTableAsync(int tableId);
    Task<Bill?> GetOpenBillByIdAsync(int billId);
    Task AddBillAsync(Bill bill);
    Task SaveChangesAsync();
}