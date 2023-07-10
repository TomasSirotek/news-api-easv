using Npgsql;

namespace Infrastructure;

public static class InfrastructureUtilityService
{
    public static readonly string
        ProperlyFormattedConnectionString = "Server=localhost;Database=postgres;Username=postgres;Password=postgres;Port=5432;Pooling=true;MaxPoolSize=3;";
    
    public static void TestDataSource(NpgsqlDataSource dataSource)
    {
        try
        {
            var conn = dataSource.OpenConnection();
            conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("\nWARNING: FIRST DOTNET RUN ARGUMENT IS NOT A VALID DATABASE CONNECTION-STRING" +
                              "\nPlease see formatting in Infrastructure/Utilities.cs for info.\n");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        
    }
}