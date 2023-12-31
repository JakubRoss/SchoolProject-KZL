﻿using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Persistance;
using System.Linq.Expressions;

namespace School.Infrastructure.Repository
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

        public async Task<List<TEntity>> ReadAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = DbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public async Task<TEntity> ReadIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] include)
        {
            var query = DbSet.Where(predicate);

            foreach (var item in include)
            {
                query = query.Include(item);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
