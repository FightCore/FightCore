using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FightCore_DAL
{
    /// <summary>
    /// GenericRepository made by Microsoft.
    /// <see href="https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application#implement-a-generic-repository-and-a-unit-of-work-class">Source</see>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepositoryAsync(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy?.Invoke(query).ToListAsync() ?? query.ToListAsync();
        }

        public virtual Task<TEntity> GetById(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public virtual Task Insert(TEntity entity)
        {
            return _dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(object id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        protected virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
