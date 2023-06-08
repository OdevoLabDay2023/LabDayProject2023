namespace WorkOrderManager.EventSourcing
{
    public static class CoffeeMachineConstants
    {
        public const string StreamName = "CoffeeMachineWorkOrder";
        
        public enum CoffeeMachineWorkOrderStatus
        {
            Registered,

            WorkerAssigned,

            Completed
        }
    }
}
