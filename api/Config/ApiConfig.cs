using api.Middleware;
using Infrastructure;
using Npgsql;

namespace api.Config;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddControllers();
            
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });
        
        if (env.IsDevelopment())
        {
            services.AddNpgsqlDataSource(InfrastructureUtilityService.ProperlyFormattedConnectionString,
                dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
        }

        if (env.IsProduction())
        {
            services.AddNpgsqlDataSource(InfrastructureUtilityService.ProperlyFormattedConnectionString);
        }
        
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        InfrastructureUtilityService.TestDataSource(app.Services.GetService<NpgsqlDataSource>()!);
        
        app.UseRouting();

        app.UseCors(options =>
        {
            options.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });

        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<RouteCheck>();
        
        app.MapControllers();
    }
}