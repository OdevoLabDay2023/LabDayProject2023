namespace WorkOrderManager.EventSourcing.Events
{
    public class CoffeeMachineBrokenEvent
    {
        public required DateTime RegistrationDate { get; init; }
        public required string OrderNumber { get; init; }
        public required string MachineNumber { get; init; }
        public required string ProblemDescription { get; init; }
        public required string ProblemReporter { get; init; }
    }
}
