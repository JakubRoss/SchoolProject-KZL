using System.Linq.Expressions;

namespace Cabanoss.Core.Repositories.Impl
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<List<TEntity>> ReadAllAsync();
        Task<TEntity> ReadIncludeAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include);
    }
}