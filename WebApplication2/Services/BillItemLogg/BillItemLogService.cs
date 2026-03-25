using WebApplication2.Data.Dtos;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class BillItemLogService(IBillItemLogRepository repository) : IBillItemLogService
{
    public async Task<List<BillItemLogDto>> GetBillLogAsync(int billId)
    {
        return await repository.GetBillItemLogsAsync(billId);
    }
}