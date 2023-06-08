using WorkOrderManager.EventSourcing.Events;
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

        public DateTime? RegistrationDate { get; set; }
        public DateTime? WorkOrderAssignedDate { get; set; }

        public DateTime? RepairDate { get; set; }

        public double? SecondsToComplete
        {
            get
            {
                if (WorkOrderAssignedDate == null || RepairDate == null)
                {
                    return null;
                }

                return RepairDate.Value.Subtract(WorkOrderAssignedDate.Value).TotalSeconds;
            }
        }

        public void Apply(CoffeeMachineBrokenEvent registration)
        {
            Status = CoffeeMachineWorkOrderStatus.Registered;
            RegistrationDate = registration.RegistrationDate;
            OrderNumber = registration.OrderNumber;
            MachineNumber = registration.MachineNumber;
            ProblemDescription = registration.ProblemDescription;
            ProblemReporter = registration.ProblemReporter;
        }

        public void Apply(CoffeeMachineRepairmanAssignedEvent repairmanAssigned)
        {
            Status = CoffeeMachineWorkOrderStatus.WorkerAssigned;
            WorkOrderAssignedDate = repairmanAssigned.AssignedDate;
            Repairman = repairmanAssigned.Repairman;
        }

        public void Apply(CoffeeMachinRepairedEvent repaired)
        {
            Status = CoffeeMachineWorkOrderStatus.Completed;
            RepairDate = repaired.RepairDate;
        }
    }
}
