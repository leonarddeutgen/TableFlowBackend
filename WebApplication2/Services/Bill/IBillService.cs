using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IBillService
{
    Task<Bill?> GetActiveBill(int tableId);
    Task<Bill?> CreateNewBill(CreateBillDto dto);
    Task<Bill?> CloseBillById(int id);
}