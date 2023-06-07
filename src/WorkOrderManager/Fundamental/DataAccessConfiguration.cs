namespace WorkOrderManager.Fundamental;

public static class DataAccessConfiguration
{
    private const string configSection = "WorkOrderDatabase";

    public static string GetRelatorTestServiceConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString(configSection) ??
               throw new ApplicationException($"ConnectionString {configSection} missing");
    }
}