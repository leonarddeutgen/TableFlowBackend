using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IBillService
{
    Task<Bill?> GetActiveBill(int tableId);
    Task<Bill?> CreateNewBill(CreateBillDto dto);
    Task<Bill?> CloseBillById(int id);
}