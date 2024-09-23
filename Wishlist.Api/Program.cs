using Microsoft.AspNetCore.Mvc;
using Serilog;
using Wishlist.Api;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateBootstrapLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSerilog();

builder.Logging.AddSerilog();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/{id:int}", (int id, [FromServices] ILogger<LoggerHelper> logger) =>
{
    if (id == 1)
    {
        logger.LogInformation("Returning product with id {Id}", id);
        return Results.Ok(new {Id = id, Name = "Product 1"});
    }

    logger.LogWarning("Product with id {Id} not found", id);
    return Results.NotFound();
});

app.UseHttpsRedirection();

app.Run();
