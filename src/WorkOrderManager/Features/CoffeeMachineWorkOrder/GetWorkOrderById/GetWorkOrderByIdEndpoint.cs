using static WorkOrderManager.EventSourcing.CoffeeMachineConstants;

namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetWorkOrderById;

public class GetWorkOrderByIdEndpoint : Endpoint<GetWorkOrderByIdRequest, GetWorkOrderByIdResponse>
{
    public override void Configure()
    {
        Get("/CoffeeMachineWorkOrder/{WorkOrderId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetWorkOrderByIdRequest request, CancellationToken ct)
    {
        var workOrder = await new GetWorkOrderByIdCommand()
        {
            WorkOrderId = Guid.Parse(request.WorkOrderId)
        }
        .ExecuteAsync(ct: ct);

        var response = new GetWorkOrderByIdResponse()
        {
            Id = workOrder.Id.ToString(),
            Status = workOrder.Status switch
            {
                CoffeeMachineWorkOrderStatus.Registered => "Problem registered",
                CoffeeMachineWorkOrderStatus.WorkerAssigned => "Assigned to worker",
                CoffeeMachineWorkOrderStatus.Completed => "Work is done",
                _ => "-"
            },
            OrderNumber = workOrder.OrderNumber,
            MachineNumber = workOrder.MachineNumber,
            ProblemDescription = workOrder.ProblemDescription,
            ProblemReporter = workOrder.ProblemReporter,
            Repairman = workOrder.Repairman
        };

        await SendAsync(response);
    }
}
