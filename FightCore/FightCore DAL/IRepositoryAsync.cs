using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FightCore_DAL
{
    public interface IRepositoryAsync<TEntity>
    {
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetById(object id);
        Task Insert(TEntity entity);
        Task Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}
