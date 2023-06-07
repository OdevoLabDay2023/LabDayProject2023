namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineIsBrokenCommand : ICommand<Guid>
{
    public required string MachineNumber { get; init; }
    public required string ProblemDescription { get; init; }
    public required string ProblemReporter { get; init; }
}