using WorkOrderManager.Database;

namespace WorkOrderManager.Features.WorkOrders.Create;

public class CreateWorkOrderCommand : ICommand<WorkOrderEntity>
{
    public required string Type { get; init; }
    public required string Description { get; init; }
    public required string? Reference { get; init; }
}