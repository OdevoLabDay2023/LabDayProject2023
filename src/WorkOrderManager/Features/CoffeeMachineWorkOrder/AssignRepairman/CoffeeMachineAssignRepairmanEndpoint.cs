namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineAssignRepairmanEndpoint : Endpoint<CoffeeMachineAssignRepairmanRequest>
{
    public override void Configure()
    {
        Post("/CoffeeMachineWorkOrder/AssignRepairman");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CoffeeMachineAssignRepairmanRequest request, CancellationToken ct)
    {
        await new CoffeeMachineAssignRepairmanCommand()
        {
            WorkOrderId = Guid.Parse(request.WorkOrderId),
            Repairman = request.Repairman
        }
        .ExecuteAsync(ct: ct);

        await SendOkAsync();
    }
}
