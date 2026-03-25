using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IBillItemLogService
{
    Task<List<BillItemLogDto>> GetBillLogAsync(int billId);
}