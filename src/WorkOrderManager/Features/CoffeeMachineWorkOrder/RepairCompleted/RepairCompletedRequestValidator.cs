namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.RepairCompleted;

public class RepairCompletedRequestValidator : Validator<RepairCompletedRequest>
{
    public RepairCompletedRequestValidator()
    {
        RuleFor(workOrder => workOrder.WorkOrderId)
            .NotNull()
            .NotEmpty();
    }
}
