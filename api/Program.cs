using api.Config;
using Infrastructure;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

//SETUP LOGGER
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// SETUP DI
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.AddApiConfiguration(builder.Environment);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration(app.Environment);

InfrastructureUtilityService.TestDataSource(app.Services.GetService<NpgsqlDataSource>()!);

app.Run();
