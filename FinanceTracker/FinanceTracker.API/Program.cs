using FinanceTracker.API.Configuration.Filters;
using FinanceTracker.Application.Configurations;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) =>
    {
        lc.ReadFrom.Configuration(ctx.Configuration);
        lc.WriteTo.Console(theme: AnsiConsoleTheme.Sixteen);
        lc.WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day);
    }
);

builder.Services.AddControllers(options => { options.Filters.Add<ResultToHttpFilter>(); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();