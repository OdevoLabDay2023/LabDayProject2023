namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.RepairCompleted;

public class RepairCompletedEndpoint : Endpoint<RepairCompletedRequest>
{
    public override void Configure()
    {
        Post("/CoffeeMachineWorkOrder/RepairCompleted");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RepairCompletedRequest request, CancellationToken ct)
    {
        await new RepairCompletedCommand()
        {
            WorkOrderId = Guid.Parse(request.WorkOrderId)
        }
        .ExecuteAsync(ct: ct);

        await SendOkAsync();
    }
}
