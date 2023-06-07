using WorkOrderManager.Fundamental;

namespace WorkOrderManager.Features.WorkOrders.Delete;
public class WorkOrderDeleteHandler : ICommandHandler<WorkOrderDeleteCommand>
{
    private WorkOrderDbContext _context;

    public WorkOrderDeleteHandler(WorkOrderDbContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(WorkOrderDeleteCommand command, CancellationToken ct = default)
    {
        var item = await _context.WorkOrder.FindAsync(command.Id) ??
            throw new Exception("WorkOrder not found");

        _context.WorkOrder.Remove(item);

        await _context.SaveChangesAsync(ct);
    }
}