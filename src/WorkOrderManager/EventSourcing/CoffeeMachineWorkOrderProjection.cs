using static WorkOrderManager.EventSourcing.CoffeeMachineConstants;

namespace WorkOrderManager.EventSourcing
{
    public class CoffeeMachineWorkOrderProjection
    {
        public Guid Id { get; set; }

        public CoffeeMachineWorkOrderStatus? Status { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string MachineNumber { get; set; } = null!;
        public string ProblemDescription { get; set; } = null!;
        public string ProblemReporter { get; set; } = null!;
        public string? Repairman { get; set; }

        public void Apply(CoffeeMachineBroken registration)
        {
            Status = CoffeeMachineWorkOrderStatus.Registered;
            OrderNumber = registration.OrderNumber;
            MachineNumber = registration.MachineNumber;
            ProblemDescription = registration.ProblemDescription;
            ProblemReporter = registration.ProblemReporter;
        }

        public void Apply(CoffeeMachineRepairmanAssigned repairmanAssigned)
        {
            Status = CoffeeMachineWorkOrderStatus.WorkerAssigned;
            Repairman = repairmanAssigned.Repairman;
        }

        public void Apply(CoffeeMachinFixed repairmanAssigned)
        {
            Status = CoffeeMachineWorkOrderStatus.Completed;
        }
    }
}
