namespace WorkOrderManager.Features.WorkOrders.Delete;

public class WorkOrderDeleteRequestValidator : Validator<WorkOrderDeleteRequest>
{
    public WorkOrderDeleteRequestValidator()
    {
        RuleFor(x => x.ID)
            .NotNull();
    }
}

