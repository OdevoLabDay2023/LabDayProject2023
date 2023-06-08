namespace WorkOrderManager.EventSourcing.Events;

public class CoffeeMachineRepairmanAssignedEvent
{
    public required DateTime AssignedDate { get; init; }
    public required string Repairman { get; init; }
}