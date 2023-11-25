using System.Linq.Expressions;

namespace School.Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<List<TEntity>> ReadAllAsync();
        Task<List<TEntity>> ReadAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> ReadIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include);
    }
}