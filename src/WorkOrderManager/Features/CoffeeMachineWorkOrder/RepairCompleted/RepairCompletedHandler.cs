using Marten;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.RepairCompleted;
public class RepairCompletedHandler : ICommandHandler<RepairCompletedCommand>
{
    private readonly IDocumentStore documentStore;

    public RepairCompletedHandler(IDocumentStore documentStore)
    {
        this.documentStore = documentStore;
    }

    public async Task ExecuteAsync(RepairCompletedCommand command, CancellationToken ct = default)
    {
        var machineFixed = new CoffeeMachinFixed()
        {
            RepairDate = DateTime.Now
        };

        await using (var session = documentStore.LightweightSession())
        {
            session.Events.Append(command.WorkOrderId, machineFixed);
            await session.SaveChangesAsync();
        }
    }
}
