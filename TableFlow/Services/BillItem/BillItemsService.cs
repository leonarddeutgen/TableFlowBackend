using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;
using TableFlow.Repositories;

namespace TableFlow.Services;

public class BillItemsService(
    IBillItemsRepository billItemsRepository,
    IBillItemLogRepository billItemLogRepository)
    : IBillItemsService
{
    public async Task<Bill> AddBillItemsAsync(AddBillItemsDto dto)
    {
        var bill = await billItemsRepository.GetBillWithItemsAsync(dto.BillId);

        if (bill == null)
            throw new Exception("Bill not found");

        if (bill.Status != BillStatus.Open)
            throw new Exception("Bill is not open");

        foreach (var item in dto.BillItems)
        {
            var product = await billItemsRepository.GetProductAsync(item.ProductId);

            if (product == null || !product.IsActive)
                throw new Exception("Invalid product");

            var existing = bill.Items
                .FirstOrDefault(i => i.ProductId == product.ProductId);

            var action = existing == null
                ? BillItemLogAction.Add
                : BillItemLogAction.Increase;

            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                bill.Items.Add(new BillItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.ProductPrice,
                    AddedAt = DateTime.UtcNow
                });
            }

            // Lägg till logg
            await billItemLogRepository.AddLogAsync(new BillItemLog
            {
                BillId = bill.BillId,
                ProductId = product.ProductId,
                QuantityChange = item.Quantity,
                UnitPrice = product.ProductPrice,
                CreatedAt = DateTime.UtcNow,
                Action = action
            });
        }

        bill.TotalAmount = bill.Items.Sum(i => i.Quantity * i.UnitPrice);

        await billItemsRepository.SaveChangesAsync();

        return bill;
    }

    public async Task<Bill> MovePartialBillItems(MoveBillItemsDto dto)
    {
        var sourceBill = await billItemsRepository.GetBillByTableIdAsync(dto.SourceTableId);
        
        if (sourceBill == null) 
            throw new Exception("Source bill not found"); 
        
        var targetBill = await billItemsRepository.GetBillByTableIdAsync(dto.TargetTableId);
        
        if (targetBill == null) 
        { 
            targetBill = new Bill 
            { 
                TableId = dto.TargetTableId,
                Status = BillStatus.Open,
                CreatedAt = DateTime.UtcNow,
                Items = new List<BillItem>(),
                OrganisationId = sourceBill.OrganisationId,
            }; 
            await billItemsRepository.AddBillAsync(targetBill);
        } 
        //
           foreach (var moveItem in dto.Items) 
        { 
            var sourceItem = sourceBill.Items
                .FirstOrDefault(i => i.BillItemId == moveItem.BillItemId); 
            
            if (sourceItem == null) 
                throw new Exception("Invalid bill item"); 
            if (moveItem.Quantity > sourceItem.Quantity)
                throw new Exception("Quantity exceeds source quantity"); 
            
            // ➖ minska från source
            sourceItem.Quantity -= moveItem.Quantity; 
            
            if (sourceItem.Quantity == 0) 
                await billItemsRepository.RemoveBillItemAsync(sourceItem);
            // Lägg till minskning i loggen
            await billItemLogRepository.AddLogAsync(new BillItemLog
            {
                Bill = sourceBill,
                ProductId = sourceItem.ProductId,
                QuantityChange = -moveItem.Quantity,
                UnitPrice = sourceItem.UnitPrice,
                CreatedAt = DateTime.UtcNow,
                Action = BillItemLogAction.Decrease
            });

            // ➕ lägg till på target
            var targetItem = targetBill.Items
                .FirstOrDefault(i => i.ProductId == sourceItem.ProductId); 
            
            if (targetItem != null)
            { 
                targetItem.Quantity += moveItem.Quantity; 
            }
            else 
            {
                targetBill.Items.Add(new BillItem
                {
                    ProductId = sourceItem.ProductId,
                    Quantity = moveItem.Quantity,
                    UnitPrice = sourceItem.UnitPrice,
                    AddedAt = DateTime.UtcNow
                });
            }

            await billItemLogRepository.AddLogAsync(new BillItemLog
            {
                Bill = targetBill,
                ProductId = sourceItem.ProductId,
                QuantityChange = moveItem.Quantity,
                UnitPrice = sourceItem.UnitPrice,
                CreatedAt = DateTime.UtcNow,
                Action = BillItemLogAction.Add
            });
        }

        sourceBill.RecalculateTotal();
        targetBill.RecalculateTotal();
        
        await billItemsRepository.SaveChangesAsync();
        return targetBill; 
    }

    public async Task<Bill> MoveWholeBill(MoveWholeBillDto dto)
    {
        if(dto.SourceTableId == dto.TargetTableId) 
            throw new Exception ("Source and target table can not be the same.");
        
        var sourceBill = await billItemsRepository.GetBillByTableIdAsync(dto.SourceTableId);
        
        if (sourceBill == null) 
            throw new  Exception("Source bill not found"); 
        
        var targetBill = await billItemsRepository.GetBillByTableIdAsync(dto.TargetTableId);
        
        if (targetBill == null)
        {
            targetBill = new Bill
            { 
                TableId = dto.TargetTableId,
                Status = BillStatus.Open,
                CreatedAt = DateTime.UtcNow,
                Items = new List<BillItem>(),
                OrganisationId = sourceBill.OrganisationId,
            }; 
            await billItemsRepository.AddBillAsync(targetBill);
        }
        
        foreach (var billItem in sourceBill.Items.ToList())
        {
            await billItemLogRepository.AddLogAsync(new BillItemLog
            {
                Bill = sourceBill,
                ProductId = billItem.ProductId,
                QuantityChange = -billItem.Quantity,
                UnitPrice = billItem.UnitPrice,
                CreatedAt = DateTime.UtcNow,
                Action = BillItemLogAction.Decrease
            });

            await billItemLogRepository.AddLogAsync(new BillItemLog
            {
                Bill = targetBill,
                ProductId = billItem.ProductId,
                QuantityChange = billItem.Quantity,
                UnitPrice = billItem.UnitPrice,
                CreatedAt = billItem.AddedAt,
                Action = BillItemLogAction.Add
            });
            
            billItem.Bill = targetBill;
        }
        
        sourceBill.Cancel();
        
        targetBill.RecalculateTotal();
        sourceBill.RecalculateTotal();

        await billItemsRepository.SaveChangesAsync();
        return targetBill;
    }
}
