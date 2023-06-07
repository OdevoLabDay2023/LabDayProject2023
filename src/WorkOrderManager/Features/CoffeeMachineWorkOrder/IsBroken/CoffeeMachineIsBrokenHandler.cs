using EventStore.Client;
using System.Text.Json;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;
public class CoffeeMachineIsBrokenHandler : ICommandHandler<CoffeeMachineIsBrokenCommand, CoffeeMachineWorkOrderProjection>
{
    //private readonly WorkOrderDbContext dbContext;
    private readonly EventStoreClient eventStoreClient;

    public CoffeeMachineIsBrokenHandler(EventStoreClient eventStoreClient)
    {
        this.eventStoreClient = eventStoreClient;
    }

    public async Task<CoffeeMachineWorkOrderProjection> ExecuteAsync(CoffeeMachineIsBrokenCommand command, CancellationToken ct = default)
    {
        var registrationEvent = new CoffeeMachineIsBrokenRegistration()
        {
            OrderNumber = GenerateRandomOrderNumber(),
            MachineNumber = command.MachineNumber,
            ProblemDescription = command.ProblemDescription,
            ProblemReporter = command.ProblemReporter
        };

        var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(registrationEvent);

        var eventData = new EventData(Uuid.NewUuid(),
                                       nameof(CoffeeMachineIsBrokenRegistration),
                                       utf8Bytes.AsMemory());

        var writeResult = await eventStoreClient.AppendToStreamAsync(
            CoffeeMachineWorkOrderConstants.StreamName,
            StreamState.Any,
            new[] { eventData });

        var item = new CoffeeMachineWorkOrderProjection()
        {
            Id = Guid.NewGuid(),
            OrderNumber = "007"
        };

        return item;
    }

    private string GenerateRandomOrderNumber()
    {
        var random = new Random();
        var year = "2023";
        var maxDigits = 10;

        var nextNumber = random.Next(1, 1000000000)
            .ToString()
            .PadLeft(maxDigits, '0');
        var formatOrderNumber = $"{year}-{nextNumber}";

        return formatOrderNumber;
    }

    //private async Task<string> GetNextOrderNumber()
    //{
    //    var year = "2023";
    //    var maxDigits = 10;

    //    var numberOfWorkorders = await dbContext.WorkOrder.CountAsync();

    //    var nextNumber = (numberOfWorkorders + 1).ToString()
    //        .PadLeft(maxDigits, '0');
    //    var formatOrderNumber = $"{year}-{nextNumber}";

    //    return formatOrderNumber;
    //}
}
