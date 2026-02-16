using FinanceTracker.Contracts.Interfaces;
using FinanceTracker.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.DataAccess.Configuration;

public static class DataAccessRegistration
{
    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration config)
    {
        var connString = config.GetConnectionString("FinanceTrackerDb");
        if (string.IsNullOrWhiteSpace(connString))
            throw new InvalidOperationException(
                "The 'FinanceTrackerDb' connection string is missing or empty. " +
                "Please configure a valid connection string in the application settings.");
        services.AddDbContext<FinanceTrackerDbContext>(opt => opt.UseSqlServer(connString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}