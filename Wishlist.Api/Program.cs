using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Templates.Themes;
using SerilogTracing;
using SerilogTracing.Expressions;
using Wishlist.Api.Endpoints;
using Wishlist.Infrastructure.Persistence.EntityFramework;

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
builder.Services.AddDbContext<WishlistDbContext>(options => { options.UseInMemoryDatabase("Wishlist"); });
builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(WishlistDbContext).Assembly); });

builder.Logging.AddSerilog();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSearchCategories();
app.MapProducts();

app.UseHttpsRedirection();

app.Run();
