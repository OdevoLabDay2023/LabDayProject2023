namespace WorkOrderManager.Features.WorkOrders.Create
{
    public class CreateWorkOrderRequestValidator : Validator<CreateWorkOrderRequest>
    {
        public CreateWorkOrderRequestValidator()
        {
            RuleFor(workOrder => workOrder.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(500);

            RuleFor(workOrder => workOrder.Type)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(10);
        }
    }
}
