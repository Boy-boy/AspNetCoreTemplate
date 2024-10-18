using Core.Modularity;
using Template.Api.DiModule;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServiceCollection<StartupDiModule>();

var app = builder.Build();
app.BuildApplicationBuilder();
app.Run();

