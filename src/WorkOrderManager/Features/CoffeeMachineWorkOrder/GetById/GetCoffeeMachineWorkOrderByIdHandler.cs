using Marten;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetById;
public class GetCoffeeMachineWorkOrderByIdHandler : ICommandHandler<GetCoffeeMachineWorkOrderByIdCommand, CoffeeMachineWorkOrderProjection>
{
    private readonly IDocumentStore documentStore;

    public GetCoffeeMachineWorkOrderByIdHandler(IDocumentStore documentStore)
    {
        this.documentStore = documentStore;
    }

    public async Task<CoffeeMachineWorkOrderProjection> ExecuteAsync(GetCoffeeMachineWorkOrderByIdCommand command, CancellationToken ct = default)
    {
        await using var session = documentStore.LightweightSession();
        
        var workOrder = await session.Events.AggregateStreamAsync<CoffeeMachineWorkOrderProjection>(command.WorkOrderId) ??
            throw new Exception("WorkOrder not found");

        return workOrder;
    }
}
