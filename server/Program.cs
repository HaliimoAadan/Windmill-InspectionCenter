using Mqtt.Controllers;
using server;

var builder = WebApplication.CreateBuilder(args);

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
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();

app.GenerateApiClientsFromOpenApi("../client/src/generated-ts-client.ts", "./openapi.json").GetAwaiter().GetResult();

var mqtt = app.Services.GetRequiredService<IMqttClientService>();
await mqtt.ConnectAsync("broker.hivemq.com", 1883);

app.Run();
