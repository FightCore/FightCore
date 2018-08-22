using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FightCore.Repositories.Patterns
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);
        Task<IEnumerable<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query);

        Task<TEntity> InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
