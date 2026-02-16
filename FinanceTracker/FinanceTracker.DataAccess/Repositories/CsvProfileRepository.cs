using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories;

public class CsvProfileRepository : Repository<CsvProfile>, ICsvProfileRepository
{
    public CsvProfileRepository(DbContext context) : base(context)
    {
    }
}