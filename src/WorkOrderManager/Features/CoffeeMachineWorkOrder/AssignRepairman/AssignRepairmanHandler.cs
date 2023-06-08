using Marten;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.AssignRepairman;
public class AssignRepairmanHandler : ICommandHandler<AssignRepairmanCommand>
{
    private readonly IDocumentStore documentStore;

    public AssignRepairmanHandler(IDocumentStore documentStore)
    {
        this.documentStore = documentStore;
    }

    public async Task ExecuteAsync(AssignRepairmanCommand command, CancellationToken ct = default)
    {
        CoffeeMachineRepairmanAssigned repairmanAssigned = new()
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
