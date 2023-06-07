namespace WorkOrderManager.EventSourcing
{
    public class CoffeeMachineWorkOrderProjection
    {
        public Guid Id { get; set; }

        public string OrderNumber { get; set; } = null!;
        public string MachineNumber { get; set; } = null!;
        public string ProblemDescription { get; set; } = null!;
        public string ProblemReporter { get; set; } = null!;
        public string? Repairman { get; set; }

        public void Apply(CoffeeMachineIsBrokenRegistration registration)
        {
            OrderNumber = registration.OrderNumber;
            MachineNumber = registration.MachineNumber;
            ProblemDescription = registration.ProblemDescription;
            ProblemReporter = registration.ProblemReporter;
        }

        public void Apply(CoffeeMachineWorkOrderRepairmanAssigned repairmanAssigned)
        {
            Repairman = repairmanAssigned.Repairman;
        }
    }
}
