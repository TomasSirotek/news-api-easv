using api.Config;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

//SETUP LOGGER
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// SETUP DI
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

// SETUP OTHER SERVICES
builder.Services.AddApiConfiguration(builder.Environment);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// USE OTHER SERVICES
app.UseApiConfiguration();
app.UseSwaggerConfiguration(app.Environment);

app.Run();
