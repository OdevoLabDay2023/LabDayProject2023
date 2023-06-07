namespace WorkOrderManager.Database;

public class WorkOrderEntity
{
    public required Guid Id { get; init; }
    public required string OrderNumber { get; set; }

    public required DateTime CreatedDate { get; set; }

    public required string Type { get; init; }
    public required string Description { get; init; }
    public required string? Reference { get; init; }
}
