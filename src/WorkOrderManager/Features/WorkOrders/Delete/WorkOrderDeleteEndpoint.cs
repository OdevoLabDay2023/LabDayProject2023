namespace WorkOrderManager.Features.WorkOrders.Delete;

public class WorkOrderDeleteEndpoint : Endpoint<WorkOrderDeleteRequest>
{
    public override void Configure()
    {
        Delete("/workorder/{ID}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(WorkOrderDeleteRequest request, CancellationToken c)
    {
        await new WorkOrderDeleteCommand()
        {
            Id = new Guid(request.ID)
        }.ExecuteAsync(c);

        await SendOkAsync();
    }
}