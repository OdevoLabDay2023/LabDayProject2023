using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetById;

public class GetCoffeeMachineWorkOrderByIdCommand : ICommand<CoffeeMachineWorkOrderProjection>
{
    public required Guid WorkOrderId { get; init; }
}