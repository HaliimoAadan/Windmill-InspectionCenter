using dotenv.net;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.EntityFrameworkCore;
using Mqtt.Controllers;
using server;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();
var dbConnectionString = 
    Environment.GetEnvironmentVariable("CONN_STR");

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpgsql(dbConnectionString);
});
builder.Services.AddMqttControllers();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddCors();

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