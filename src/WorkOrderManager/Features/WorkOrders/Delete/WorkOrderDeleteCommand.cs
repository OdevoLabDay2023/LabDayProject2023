namespace WorkOrderManager.Features.WorkOrders.Delete;

public class WorkOrderDeleteCommand : ICommand
{
    public required Guid Id { get; set; }
}

