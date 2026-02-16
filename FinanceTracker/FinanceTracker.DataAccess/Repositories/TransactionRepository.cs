using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(DbContext context) : base(context)
    {
    }
}