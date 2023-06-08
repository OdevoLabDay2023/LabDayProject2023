namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class IsBrokenRequestValidator : Validator<IsBrokenRequest>
{
    public IsBrokenRequestValidator()
    {
        RuleFor(x => x.MachineNumber)
            .NotNull()
            .NotEmpty()
            .Length(10);

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(500);

        RuleFor(x => x.Reporter)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }
}
