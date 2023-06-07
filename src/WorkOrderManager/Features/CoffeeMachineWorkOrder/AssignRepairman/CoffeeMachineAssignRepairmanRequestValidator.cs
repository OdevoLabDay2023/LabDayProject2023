namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class CoffeeMachineAssignRepairmanRequestValidator : Validator<CoffeeMachineAssignRepairmanRequest>
{
    public CoffeeMachineAssignRepairmanRequestValidator()
    {
        RuleFor(workOrder => workOrder.WorkOrderId)
            .NotNull()
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(20);


        RuleFor(workOrder => workOrder.Repairman)
            .NotNull()
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(20);
    }
}
