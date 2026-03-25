using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;


namespace WebApplication2.Repositories;

public interface IBillItemLogRepository
{
    Task<List<BillItemLogDto>> GetBillItemLogsAsync(int billId);
    Task AddLogAsync(BillItemLog log);

}