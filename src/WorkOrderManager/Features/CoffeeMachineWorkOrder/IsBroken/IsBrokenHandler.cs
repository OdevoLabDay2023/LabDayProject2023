using Marten;
using System.Security.Cryptography;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;
public class IsBrokenHandler : ICommandHandler<IsBrokenCommand, Guid>
{
    private readonly IDocumentStore documentStore;

    public IsBrokenHandler(IDocumentStore documentStore)
    {
        this.documentStore = documentStore;
    }

    public async Task<Guid> ExecuteAsync(IsBrokenCommand command, CancellationToken ct = default)
    {
        var registrationEvent = new CoffeeMachineBroken()
        {
            OrderNumber = GenerateRandomOrderNumber(),
            MachineNumber = command.MachineNumber,
            ProblemDescription = command.ProblemDescription,
            ProblemReporter = command.ProblemReporter
        };

        var workOrderId = Guid.NewGuid();
        await using (var session = documentStore.LightweightSession())
        {
            session.Events.StartStream<CoffeeMachineWorkOrderProjection>(workOrderId, registrationEvent);
            await session.SaveChangesAsync();
        }

        return workOrderId;
    }

    private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

    private string GenerateRandomOrderNumber()
    {
        var bytes = new byte[8];
        rng.GetBytes(bytes);

        return BitConverter.ToUInt64(bytes, 0).ToString();
    }

}
