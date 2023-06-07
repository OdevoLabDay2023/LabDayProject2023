namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.GetById;

public class GetCoffeeMachineWorkOrderRequestValidator : Validator<GetCoffeeMachineWorkOrderByRequest>
{
    public GetCoffeeMachineWorkOrderRequestValidator()
    {
        RuleFor(workOrder => workOrder.WorkOrderId)
            .NotNull();
    }
}
