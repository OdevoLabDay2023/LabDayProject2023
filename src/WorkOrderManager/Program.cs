global using FastEndpoints;
global using FluentValidation;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WorkOrderManager.Fundamental;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

var connectionString = DataAccessConfiguration.GetRelatorTestServiceConnectionString(builder.Configuration);
builder.Services.AddDbContextFactory<WorkOrderDbContext, WorkOrderDbContextFactory>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
