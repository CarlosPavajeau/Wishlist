using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using Serilog.Templates.Themes;
using SerilogTracing;
using SerilogTracing.Expressions;
using Wishlist.Api;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .Enrich.WithProperty("Application", "Whishlist.Api")
    .WriteTo.Console(Formatters.CreateConsoleTextFormatter(theme: TemplateTheme.Code))
    .ReadFrom.Configuration(builder.Configuration)
    .CreateBootstrapLogger();

using var listener = new ActivityListenerConfiguration()
    .Instrument.AspNetCoreRequests()
    .TraceToSharedLogger();

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
    switch (id)
    {
        case 1:
            logger.LogInformation("Returning product with id {Id}", id);
            return Results.Ok(new {Id = id, Name = "Product 1"});
        case 3:
            logger.LogError("Product with id {Id} not supported", id);
            return Results.BadRequest("Product not supported");
    }

    logger.LogWarning("Product with id {Id} not found", id);
    return Results.NotFound();
});

app.UseHttpsRedirection();

app.Run();
