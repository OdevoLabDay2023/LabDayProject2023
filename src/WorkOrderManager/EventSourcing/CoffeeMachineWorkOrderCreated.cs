namespace WorkOrderManager.EventSourcing
{
    public class CoffeeMachineIsBrokenRegistration
    {
        public required string OrderNumber { get; init; }
        public required string MachineNumber { get; init; }
        public required string ProblemDescription { get; init; }
        public required string ProblemReporter { get; init; }
    }
}
