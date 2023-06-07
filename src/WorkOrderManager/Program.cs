global using FastEndpoints;
global using FluentValidation;
using Marten;
using Marten.Events.Projections;
using Microsoft.EntityFrameworkCore;
using Weasel.Core;
using WorkOrderManager.EventSourcing;
using WorkOrderManager.Fundamental;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

var connectionString = DataAccessConfiguration.GetRelatorTestServiceConnectionString(builder.Configuration);
builder.Services.AddDbContextFactory<WorkOrderDbContext, WorkOrderDbContextFactory>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Marten")!);
    options.AutoCreateSchemaObjects = AutoCreate.All;
    options.Projections.Snapshot<CoffeeMachineWorkOrderProjection>(SnapshotLifecycle.Inline);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
