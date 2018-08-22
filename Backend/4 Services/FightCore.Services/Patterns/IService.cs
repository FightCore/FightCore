using System.Collections.Generic;
using System.Threading.Tasks;

namespace FightCore.Services.Patterns
{
    public interface IService<TEntity> where TEntity : class
    {
        void Delete(params TEntity[] entities);

        void Delete(TEntity entity);

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        IEnumerable<TEntity> InsertRange(params TEntity[] entities);

        Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> UpdateRange(params TEntity[] entities);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
