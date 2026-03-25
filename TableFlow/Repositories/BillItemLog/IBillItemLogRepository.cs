using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;


namespace TableFlow.Repositories;

public interface IBillItemLogRepository
{
    Task<List<BillItemLogDto>> GetBillItemLogsAsync(int billId);
    Task AddLogAsync(BillItemLog log);

}