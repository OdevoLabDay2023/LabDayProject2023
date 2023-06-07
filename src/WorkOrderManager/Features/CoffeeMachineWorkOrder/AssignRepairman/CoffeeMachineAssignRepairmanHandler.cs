using Microsoft.EntityFrameworkCore;
using WorkOrderManager.EventSourcing;
using WorkOrderManager.Fundamental;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;
public class CoffeeMachineAssignRepairmanHandler : ICommandHandler<CoffeeMachineAssignRepairmanCommand, CoffeeMachineWorkOrderProjection>
{
    private readonly WorkOrderDbContext dbContext;

    public CoffeeMachineAssignRepairmanHandler(WorkOrderDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public Task<CoffeeMachineWorkOrderProjection> ExecuteAsync(CoffeeMachineAssignRepairmanCommand command, CancellationToken ct = default)
    {
        //var orderNumber = await GetNextOrderNumber();

        //var item = new WorkOrderEntity()
        //{
        //    Id = Guid.NewGuid(),
        //    CreatedDate = DateTime.Now,
        //    OrderNumber = orderNumber,
        //    Type = command.Type,
        //    Description = command.Description,
        //    Reference = command.Reference
        //};

        //dbContext.WorkOrder.Add(item);

        //await dbContext.SaveChangesAsync();

        //return item;

        var item = new CoffeeMachineWorkOrderProjection()
        {
            Id = Guid.NewGuid(),
            OrderNumber = "007"
        };

        return Task.FromResult(item);
    }

    private async Task<string> GetNextOrderNumber()
    {
        var year = "2023";
        var maxDigits = 10;

        var numberOfWorkorders = await dbContext.WorkOrder.CountAsync();

        var nextNumber = (numberOfWorkorders + 1).ToString()
            .PadLeft(maxDigits, '0');
        var formatOrderNumber = $"{year}-{nextNumber}";

        return formatOrderNumber;
    }
}
