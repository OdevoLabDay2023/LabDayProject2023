namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class IsBrokenEndpoint : Endpoint<IsBrokenRequest, IsBrokenResponse>
{
    public override void Configure()
    {
        Post("/CoffeeMachineWorkOrder/IsBroken");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IsBrokenRequest request, CancellationToken ct)
    {
        var workOrder = await new IsBrokenCommand()
        {
            MachineNumber = request.MachineNumber,
            ProblemDescription = request.Description,
            ProblemReporter = request.Reporter
        }
        .ExecuteAsync(ct: ct);

        var response = new IsBrokenResponse()
        {
            WorkOrderId = workOrder.ToString()
        };

        await SendAsync(response);
    }
}
