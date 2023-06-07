namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetById;

public class GetCoffeeMachineWorkOrderByIdEndpoint : Endpoint<GetCoffeeMachineWorkOrderByRequest, GetCoffeeMachineWorkOrderByIdResponse>
{
    public override void Configure()
    {
        Get("/CoffeeMachineWorkOrder/{WorkOrderId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCoffeeMachineWorkOrderByRequest request, CancellationToken ct)
    {
        var workOrder = await new GetCoffeeMachineWorkOrderByIdCommand()
        {
            WorkOrderId = Guid.Parse(request.WorkOrderId)
        }
        .ExecuteAsync(ct: ct);

        var response = new GetCoffeeMachineWorkOrderByIdResponse()
        {
            Id = workOrder.Id.ToString(),
            OrderNumber = workOrder.OrderNumber,
            MachineNumber = workOrder.MachineNumber,
            ProblemDescription = workOrder.ProblemDescription,
            ProblemReporter = workOrder.ProblemReporter,
            Repairman = workOrder.Repairman
        };

        await SendAsync(response);
    }
}
