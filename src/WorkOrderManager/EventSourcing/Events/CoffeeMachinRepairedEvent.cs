namespace WorkOrderManager.EventSourcing.Events
{
    public class CoffeeMachinRepairedEvent
    {
        public required DateTime RepairDate { get; init; }
    }
}
