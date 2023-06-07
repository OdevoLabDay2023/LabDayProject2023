namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineAssignRepairmanCommand : ICommand
{
    public required Guid WorkOrderId { get; init; }
    public required string Repairman { get; init; }
}