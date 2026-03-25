using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IBillItemsService
{
    Task<Bill> AddBillItemsAsync(AddBillItemsDto dto);
    Task<Bill> MovePartialBillItems(MoveBillItemsDto dto);
    
    Task<Bill> MoveWholeBill(MoveWholeBillDto dto);
}