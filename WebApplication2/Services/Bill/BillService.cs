using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Exceptions;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepository;

    public BillService(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<Bill?> GetActiveBill(int tableId)
    {
        var activeBill = await _billRepository.GetBillAsync(tableId);
        
        if (activeBill == null)
        {
            throw new KeyNotFoundException($"No active bill found for table {tableId}");
        }
        return activeBill;
    }

    public async Task<Bill?> CreateNewBill(CreateBillDto dto)
    {
        var existingBill = await _billRepository.GetOpenBillByTableAsync(dto.TableId);
        
        if (existingBill != null)
        {
            throw new BillAlreadyExistsException($"Table {dto.TableId} already has an open bill.");
        }

        var newBill = new Bill()
        {
            TableId = dto.TableId,
            OrganisationId = dto.OrganisationId,
            Status = BillStatus.Open,
            CreatedAt = DateTime.UtcNow,
            TotalAmount = 0,
        };
        
        _billRepository.AddBillAsync(newBill);
       await _billRepository.SaveChangesAsync();
        
        return newBill;
    }

    public async Task<Bill?> CloseBillById(int billId)
    {
        var billToRemove = await _billRepository.GetOpenBillByIdAsync(billId);
        
        if (billToRemove == null)
        {
            throw new NoActiveBill($"Bill with id {billId} is not open.");
        }
        
        billToRemove.Status = BillStatus.Paid;
        await _billRepository.SaveChangesAsync();
        return billToRemove;
    }
}