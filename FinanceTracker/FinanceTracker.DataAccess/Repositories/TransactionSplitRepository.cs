using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories;

public class TransactionSplitRepository : Repository<TransactionSplit>, ITransactionSplitRepository
{
    public TransactionSplitRepository(DbContext context) : base(context)
    {
    }
}