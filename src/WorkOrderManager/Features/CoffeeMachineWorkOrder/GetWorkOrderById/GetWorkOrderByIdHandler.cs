using Marten;
using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetWorkOrderById;
public class GetWorkOrderByIdHandler : ICommandHandler<GetWorkOrderByIdCommand, CoffeeMachineWorkOrderProjection>
{
    private readonly IDocumentStore documentStore;

    public GetWorkOrderByIdHandler(IDocumentStore documentStore)
    {
        this.documentStore = documentStore;
    }

    public async Task<CoffeeMachineWorkOrderProjection> ExecuteAsync(GetWorkOrderByIdCommand command, CancellationToken ct = default)
    {
        await using var session = documentStore.LightweightSession();

        var workOrder = await session.Events.AggregateStreamAsync<CoffeeMachineWorkOrderProjection>(command.WorkOrderId) ??
            throw new Exception("WorkOrder not found");

        return workOrder;
    }
}
