using WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.AssignRepairman;

public class AssignRepairmanEndpoint : Endpoint<AssignRepairmanRequest>
{
    public override void Configure()
    {
        Post("/CoffeeMachineWorkOrder/AssignRepairman");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AssignRepairmanRequest request, CancellationToken ct)
    {
        await new AssignRepairmanCommand()
        {
            WorkOrderId = Guid.Parse(request.WorkOrderId),
            Repairman = request.Repairman
        }
        .ExecuteAsync(ct: ct);

        await SendOkAsync();
    }
}
