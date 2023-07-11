using Npgsql;

namespace Infrastructure;

public static class InfrastructureUtilityService
{
    // 1. Elephantsql.com
   // private static readonly Uri Uri = new Uri(Environment.GetEnvironmentVariable("pgconn")!);
    
    // 2. Local docker-compose config
    public const string ProperlyFormattedConnectionString = "Server=localhost;Database=postgres;Username=postgres;Password=postgres;Port=5432;Pooling=true;MaxPoolSize=3;";
    
    // public static readonly string ProperlyFormattedConnectionString =
    // string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4};Pooling=true;MaxPoolSize=3",
    //     Uri.Host,
    //     Uri.AbsolutePath.Trim('/'),
    //     Uri.UserInfo.Split(':')[0],
    //     Uri.UserInfo.Split(':')[1],
    //     Uri.Port > 0 ? Uri.Port : 5432);
    
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