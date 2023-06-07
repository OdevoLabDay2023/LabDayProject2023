namespace WorkOrderManager.EventSourcing
{
    public class CoffeeMachineWorkOrderProjection
    {
        public required Guid Id { get; init; }
        public required string OrderNumber { get; set; }

    }
}
