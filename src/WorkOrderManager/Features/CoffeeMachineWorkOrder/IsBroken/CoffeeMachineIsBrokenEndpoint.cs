namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineIsBrokenEndpoint : Endpoint<CoffeeMachineIsBrokenRequest, CoffeeMachineIsBrokenResponse>
{
    public override void Configure()
    {
        Post("/CoffeeMachineWorkOrder/IsBroken");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CoffeeMachineIsBrokenRequest request, CancellationToken ct)
    {
        var workOrder = await new CoffeeMachineIsBrokenCommand()
        {
            MachineNumber = request.MachineNumber,
            ProblemDescription = request.Description,
            ProblemReporter = request.Reporter
        }
        .ExecuteAsync(ct: ct);

        var response = new CoffeeMachineIsBrokenResponse()
        {
            WorkOrderId = workOrder.ToString()
        };

        await SendAsync(response);
    }
}
