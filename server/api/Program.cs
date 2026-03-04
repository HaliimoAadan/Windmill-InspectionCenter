using System.Reflection;
using api.AppOptions;
using api.Services.Implementations;
using dotenv.net;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mqtt.Controllers;
using server;

var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Services.AddAppOptions(builder.Configuration);

builder.Services.AddDbContext<MyDbContext>(conf =>
{ conf.UseNpgsql(appOptions.DbConnectionString); });

builder.Services.AddMqttControllers();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddCors();

// Add Scoped all Services in api/Services/Implementations
var interfaceAssembly = Assembly.GetExecutingAssembly();
var serviceTypes = interfaceAssembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "api.Services.Implementations");
foreach (var implementation in serviceTypes)
{
    var iface = implementation.GetInterfaces().FirstOrDefault();
    if (iface != null)
        builder.Services.AddScoped(iface, implementation);
}

var app = builder.Build();
app.UseCors(c =>
    c.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .SetIsOriginAllowed(_ => true));

app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();

app.GenerateApiClientsFromOpenApi("../../client/src/generated-ts-client.ts", "./openapi.json");

var mqtt = app.Services.GetRequiredService<IMqttClientService>();
await mqtt.ConnectAsync("broker.hivemq.com", 1883);

app.Run();