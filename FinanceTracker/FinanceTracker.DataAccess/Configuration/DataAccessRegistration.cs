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
        services.AddDbContext<FinanceTrackerDbContext>(opt => opt.UseSqlServer(connString));
    }
}