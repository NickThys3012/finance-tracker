using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    public AccountRepository(DbContext context) : base(context)
    {
    }
}