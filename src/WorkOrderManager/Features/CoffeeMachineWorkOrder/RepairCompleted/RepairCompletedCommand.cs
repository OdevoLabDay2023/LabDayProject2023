namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.RepairCompleted;

public class RepairCompletedCommand : ICommand
{
    public required Guid WorkOrderId { get; init; }
}