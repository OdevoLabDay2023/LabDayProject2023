namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.AssignRepairman;

public class AssignRepairmanCommand : ICommand
{
    public required Guid WorkOrderId { get; init; }
    public required string Repairman { get; init; }
}