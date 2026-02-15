using System.Linq.Expressions;
using FinanceTracker.Domain.Base;

namespace FinanceTracker.Contracts.Interfaces.Base;

public interface IRepository<TModel> where TModel : BaseClass
{
    Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<TModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TModel?> SingleAsync(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
    void Create(TModel toCreate);
    void Update(TModel toUpdate);
    void Update(IEnumerable<TModel> toUpdate);
    void Delete(TModel toDelete);
}