namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.AssignRepairman;

public class AssignRepairmanRequest
{
    public required string WorkOrderId { get; init; }
    public required string Repairman { get; init; }
}
