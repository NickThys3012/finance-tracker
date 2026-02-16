using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories;

public class ImportBatchRepository : Repository<ImportBatch>, IImportBatchRepository
{
    public ImportBatchRepository(DbContext context) : base(context)
    {
    }
}