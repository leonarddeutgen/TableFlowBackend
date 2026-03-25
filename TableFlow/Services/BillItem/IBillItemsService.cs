using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IBillItemsService
{
    Task<Bill> AddBillItemsAsync(AddBillItemsDto dto);
    Task<Bill> MovePartialBillItems(MoveBillItemsDto dto);
    
    Task<Bill> MoveWholeBill(MoveWholeBillDto dto);
}