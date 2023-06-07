namespace WorkOrderManager.Features.WorkOrders.Create;

public class CreateWorkOrderEndpoint : Endpoint<CreateWorkOrderRequest, CreateWorkOrderResponse>
{
    public override void Configure()
    {
        Post("/api/workorder/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateWorkOrderRequest request, CancellationToken ct)
    {
        var workOrder = await new CreateWorkOrderCommand()
        {
            Type = request.Type,
            Reference = request.Reference,
            Description = request.Description
        }
        .ExecuteAsync(ct: ct);

        var response = new CreateWorkOrderResponse()
        {
            WorkOrderId = workOrder.Id.ToString(),
            WorkOrderNumber = workOrder.OrderNumber
        };

        await SendAsync(response);
    }
}
