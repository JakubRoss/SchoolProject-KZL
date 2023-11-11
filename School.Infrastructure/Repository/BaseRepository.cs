using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Persistance;
using System.Linq.Expressions;

namespace Cabanoss.Core.Repositories.Impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private SchoolDbContext Context { get; }
        private DbSet<TEntity> DbSet;
        public BaseRepository(SchoolDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }
        public async Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        //extension
        public async Task<List<TEntity>> ReadAllAsync()
        {
            var list = await DbSet.ToListAsync();
            return list;
        }

        public async Task<TEntity> ReadIncludeAsync(Expression<Func<TEntity, bool>> predicate,  Expression<Func<TEntity, object>> include)
        {
            var obj = DbSet.Where(predicate).Include(include);

            return await obj.FirstOrDefaultAsync();
        }
    }
}
