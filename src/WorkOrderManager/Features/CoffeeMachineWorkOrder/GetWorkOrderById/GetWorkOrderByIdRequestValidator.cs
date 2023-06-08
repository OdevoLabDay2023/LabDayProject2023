namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetWorkOrderById;

public class GetWorkOrderByIdRequestValidator : Validator<GetWorkOrderByIdRequest>
{
    public GetWorkOrderByIdRequestValidator()
    {
        RuleFor(workOrder => workOrder.WorkOrderId)
            .NotNull();
    }
}
