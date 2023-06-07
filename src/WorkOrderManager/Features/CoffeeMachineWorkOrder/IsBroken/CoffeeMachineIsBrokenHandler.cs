using EventStore.Client;
using System.Reflection.Emit;
using System.Security.Cryptography;
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

    private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

    private string GenerateRandomOrderNumber()
    {
        var bytes = new byte[8];
        rng.GetBytes(bytes);

        return BitConverter.ToUInt64(bytes, 0).ToString();
    }

}
