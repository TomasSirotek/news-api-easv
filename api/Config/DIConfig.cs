// Purpose: Configure dependency injection for the API.

using api.Helpers;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Service;
using Service.Service;
using Service.Service.Interface;

namespace api.Config;

public static class DiConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<ResponseHelper>();
        services.AddTransient<IArticleService, ArticleService>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<IArticleRepository, ArticleRepository>();
    }
}