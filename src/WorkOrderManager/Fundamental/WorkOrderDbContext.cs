

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

using Microsoft.EntityFrameworkCore;
using WorkOrderManager.Database;

namespace WorkOrderManager.Fundamental;

public class WorkOrderDbContext : DbContext
{
    public WorkOrderDbContext(DbContextOptions<WorkOrderDbContext> options) : base(options)
    {
    }
    public DbSet<WorkOrderEntity> WorkOrder { get; private set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkOrderDbContext).Assembly);
    }
}