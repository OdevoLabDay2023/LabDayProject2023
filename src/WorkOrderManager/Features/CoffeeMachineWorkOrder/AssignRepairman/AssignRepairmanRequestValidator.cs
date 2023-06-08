namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.AssignRepairman;

public class AssignRepairmanRequestValidator : Validator<AssignRepairmanRequest>
{
    public AssignRepairmanRequestValidator()
    {
        RuleFor(workOrder => workOrder.WorkOrderId)
            .NotNull()
            .NotEmpty();


        RuleFor(workOrder => workOrder.Repairman)
            .NotNull()
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(20);
    }
}
