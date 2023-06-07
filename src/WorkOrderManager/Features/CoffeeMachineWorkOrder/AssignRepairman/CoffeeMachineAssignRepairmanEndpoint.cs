namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineAssignRepairmanEndpoint : Endpoint<CoffeeMachineAssignRepairmanRequest, CoffeeMachineAssignRepairmanResponse>
{
    public override void Configure()
    {
        Post("/CoffeeMachineWorkOrder/AssignRepairman");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CoffeeMachineAssignRepairmanRequest request, CancellationToken ct)
    {
        var workOrder = await new CoffeeMachineAssignRepairmanCommand()
        {
            MachineNumber = request.MachineNumber,
            ProblemDescription = request.Description,
            ProblemReporter = request.Reporter
        }
        .ExecuteAsync(ct: ct);

        await SendAsync(new CoffeeMachineAssignRepairmanResponse());
    }
}
