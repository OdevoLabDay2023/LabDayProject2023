using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetWorkOrderById;

public class GetWorkOrderByIdCommand : ICommand<CoffeeMachineWorkOrderProjection>
{
    public required Guid WorkOrderId { get; init; }
}