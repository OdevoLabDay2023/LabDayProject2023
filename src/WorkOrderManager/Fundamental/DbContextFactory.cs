
using Microsoft.EntityFrameworkCore;

namespace WorkOrderManager.Fundamental;

public class WorkOrderDbContextFactory : IDbContextFactory<WorkOrderDbContext>
{
    private string ConnectionString { get; }

    public WorkOrderDbContextFactory(IConfiguration configuration)
    {
        ConnectionString = DataAccessConfiguration.GetRelatorTestServiceConnectionString(configuration);
    }

    public WorkOrderDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<WorkOrderDbContext>()
            .UseSqlServer(ConnectionString);

        var options = optionsBuilder.Options;
        var dbContext = new WorkOrderDbContext(options);

        return dbContext;
    }
}