using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IBillItemLogService
{
    Task<List<BillItemLogDto>> GetBillLogAsync(int billId);
}