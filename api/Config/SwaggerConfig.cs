using Microsoft.OpenApi.Models;

namespace api.Config;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "News API",
                Version = "v1",
                Description = "This is development API"
            });
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "News api v1"); });
    }
}