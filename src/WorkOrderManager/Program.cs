global using FastEndpoints;
global using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WorkOrderManager.Fundamental;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

var connectionString = DataAccessConfiguration.GetRelatorTestServiceConnectionString(builder.Configuration);
builder.Services.AddDbContextFactory<WorkOrderDbContext, WorkOrderDbContextFactory>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddEventStoreClient(new Uri("esdb://localhost:2113?Insecure=true;tlsVerifyCert=false"));
builder.Services.AddEventStoreClient(new Uri("esdb://localhost:2113"));


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
