namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetWorkOrderById;

public class GetWorkOrderByIdResponse
{
    public required string Id { get; set; }
    public required string Status { get; set; }
    public required string OrderNumber { get; set; }
    public required string MachineNumber { get; set; }
    public required string ProblemDescription { get; set; }
    public required string ProblemReporter { get; set; }
    public required string? Repairman { get; set; }
}
