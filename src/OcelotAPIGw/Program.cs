using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotAPIGw;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false, true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration).AddDelegatingHandler<AuthenticationHandler>(true);

var app = builder.Build();

await app.UseOcelot();

app.Run();
