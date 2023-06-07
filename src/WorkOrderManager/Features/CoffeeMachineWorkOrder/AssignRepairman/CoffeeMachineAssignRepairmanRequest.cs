namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineAssignRepairmanRequest
{
    public required string WorkOrderId { get; init; }
    public required string Repairman { get; init; }
}
