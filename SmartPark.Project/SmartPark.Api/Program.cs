using Microsoft.OpenApi.Models;
using SmartPark.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartPark API",
        Version = "v1",
        Description = "API para gerenciamento de estacionamentos."
    });
});

builder.Services.ConfigureInMemoryDb();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureUseCases();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartPark API v1");
        c.RoutePrefix = "swagger"; // URL: /swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
