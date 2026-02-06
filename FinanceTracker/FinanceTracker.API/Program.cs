using FinanceTracker.API.Configuration.Filters;
using FinanceTracker.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);


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