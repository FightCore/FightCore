using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Patterns
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        protected IQueryable<TEntity> Queryable { get => _dbSet; }

        public Repository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public virtual void Delete(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.FirstOrDefault(query);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbSet.FirstOrDefaultAsync(query);
        }

        public virtual IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).ToArray();
        }

        public virtual async Task<IEnumerable<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbSet.Where(query).ToArrayAsync();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> InsertRange(params TEntity[] entities)
        {
            _dbSet.AddRange(entities);
            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> UpdateRange(params TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        
        protected DbSet<T> Set<T>() where T : class => _context.Set<T>();
    }
}
