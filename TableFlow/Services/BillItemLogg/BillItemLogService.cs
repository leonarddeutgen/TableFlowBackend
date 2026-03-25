using TableFlow.Data.Dtos;
using TableFlow.Repositories;

namespace TableFlow.Services;

public class BillItemLogService(IBillItemLogRepository repository) : IBillItemLogService
{
    public async Task<List<BillItemLogDto>> GetBillLogAsync(int billId)
    {
        return await repository.GetBillItemLogsAsync(billId);
    }
}