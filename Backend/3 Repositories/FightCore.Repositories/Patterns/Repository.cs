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
        private readonly DbSet<TEntity> _databaseSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context wanting to be used.</param>
        public Repository(DbContext context)
        {
            _databaseSet = context.Set<TEntity>();
        }

        protected IQueryable<TEntity> Queryable => _databaseSet;

        /// <inheritdoc />
        public virtual void Delete(params TEntity[] keyValues)
        {
            _databaseSet.RemoveRange(keyValues);
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            _databaseSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return _databaseSet.FirstOrDefault(query);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return _databaseSet.FirstOrDefaultAsync(query);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query)
        {
            return _databaseSet.Where(query).ToArray();
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _databaseSet.Where(query).ToArrayAsync();
        }

        /// <inheritdoc />
        public virtual TEntity Insert(TEntity entity)
        {
            _databaseSet.Add(entity);
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _databaseSet.AddAsync(entity);
            return entity;
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> InsertRange(params TEntity[] entities)
        {
            _databaseSet.AddRange(entities);
            return entities;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities)
        {
            await _databaseSet.AddRangeAsync(entities);
            return entities;
        }

        /// <inheritdoc />
        public virtual TEntity Update(TEntity entity)
        {
            _databaseSet.Update(entity);
            return entity;
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> UpdateRange(params TEntity[] entities)
        {
            _databaseSet.UpdateRange(entities);
            return entities;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _databaseSet.ToListAsync();
        }
    }
}
