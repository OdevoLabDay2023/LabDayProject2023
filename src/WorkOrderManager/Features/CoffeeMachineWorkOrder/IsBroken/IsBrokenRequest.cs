﻿namespace WorkOrderManager.Features.CoffeeMachineWorkOrder.IsBroken;

public class IsBrokenRequest
{
    public required string MachineNumber { get; init; }
    public required string Description { get; init; }
    public required string Reporter { get; init; }
}
