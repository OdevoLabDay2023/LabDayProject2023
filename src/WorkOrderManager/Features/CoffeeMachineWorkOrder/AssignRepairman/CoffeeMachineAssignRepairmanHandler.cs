using Marten;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;
public class CoffeeMachineAssignRepairmanHandler : ICommandHandler<CoffeeMachineAssignRepairmanCommand>
{
    private readonly IDocumentStore documentStore;

    public CoffeeMachineAssignRepairmanHandler(IDocumentStore documentStore)
    {
        this.documentStore = documentStore;
    }

    public async Task ExecuteAsync(CoffeeMachineAssignRepairmanCommand command, CancellationToken ct = default)
    {
        CoffeeMachineWorkOrderRepairmanAssigned repairmanAssigned = new()
        {
            Repairman = command.Repairman
        };

        await using (var session = documentStore.LightweightSession())
        {
            session.Events.Append(command.WorkOrderId, repairmanAssigned);
            await session.SaveChangesAsync();
        }
    }
}
