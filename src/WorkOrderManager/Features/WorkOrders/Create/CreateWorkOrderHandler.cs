using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkOrderManager.Database;
using WorkOrderManager.Fundamental;

namespace WorkOrderManager.Features.WorkOrders.Create;
public class CreateWorkOrderHandler : ICommandHandler<CreateWorkOrderCommand, WorkOrderEntity>
{
    private readonly WorkOrderDbContext dbContext;

    public CreateWorkOrderHandler(WorkOrderDbContext dbContext)
    {
        this.dbContext = dbContext;

        WriteToFile("/dasd", "asd");
    }
    
    public async Task<WorkOrderEntity> ExecuteAsync(CreateWorkOrderCommand command, CancellationToken ct = default)
    {
        var orderNumber = await GetNextOrderNumber();
        var orderNumber2 = await GetNextOrderNumber_foo("2003");

        var item = new WorkOrderEntity()
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            OrderNumber = orderNumber,
            Type = command.Type,
            Description = command.Description,
            Reference = command.Reference
        };

        item.OrderNumber = orderNumber2;

        dbContext.WorkOrder.Add(item);

        await dbContext.SaveChangesAsync();

        return item;
    }
    
    private FileStream WriteToFile(string path, string text)
    {
        using var fs = File.Create(path);
        var bytes = Encoding.UTF8.GetBytes(text);
        fs.Write(bytes, 0, bytes.Length);
        return fs;
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

    private async Task<string> GetNextOrderNumber_foo(string foo2)
    {
        var year = foo2;
        var maxDigits = 10;

        var numberOfWorkorders = await dbContext.WorkOrder.CountAsync();

        var nextNumber = (numberOfWorkorders + 1).ToString()
            .PadLeft(maxDigits, '0');
        var formatOrderNumber = $"{year}-{nextNumber}";

        return formatOrderNumber;
    }
}
