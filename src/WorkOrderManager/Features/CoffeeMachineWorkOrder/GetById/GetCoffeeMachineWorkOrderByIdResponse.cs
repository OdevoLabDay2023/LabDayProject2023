namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetById;

public class GetCoffeeMachineWorkOrderByIdResponse
{
    public required string Id { get; set; }
    public required string OrderNumber { get; set; }
    public required string MachineNumber { get; set; }
    public required string ProblemDescription { get; set; }
    public required string ProblemReporter { get; set; }
    public required string? Repairman { get; set; }
}
