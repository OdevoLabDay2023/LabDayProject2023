using WorkOrderManager.EventSourcing;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineIsBrokenCommand : ICommand<CoffeeMachineWorkOrderProjection>
{
    public required string MachineNumber { get; init; }
    public required string ProblemDescription { get; init; }
    public required string ProblemReporter { get; init; }
}