namespace WorkOrderManager.Features.WorkOrders.Create;

public class CreateWorkOrderRequest
{
    public required string Type { get; init; }
    public required string Description { get; init; }
    public required string? Reference { get; init; }
}
