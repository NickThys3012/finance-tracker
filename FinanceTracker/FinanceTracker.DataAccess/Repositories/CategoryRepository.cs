using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.DataAccess.Repositories.Base;
using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
}