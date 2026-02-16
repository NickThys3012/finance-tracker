using System.Linq.Expressions;
using FinanceTracker.Contracts.Interfaces.Base;
using FinanceTracker.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.Repositories.Base;

public class Repository<TModel> : IRepository<TModel> where TModel : BaseClass
{
    protected readonly DbSet<TModel> DbSet;

    protected Repository(DbContext context)
    {
        DbSet = context.Set<TModel>();
    }

    public Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return DbSet.ToListAsync(cancellationToken);
    }

    public Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return DbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public Task<TModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return DbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }


    public Task<TModel?> SingleAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public void Create(TModel toCreate)
    {
        DbSet.Add(toCreate);
    }

    public void Update(TModel toUpdate)
    {
        DbSet.Update(toUpdate);
    }

    public void Update(IEnumerable<TModel> toUpdate)
    {
        DbSet.UpdateRange(toUpdate);
    }

    public void Delete(TModel toDelete)
    {
        DbSet.Remove(toDelete);
    }
}