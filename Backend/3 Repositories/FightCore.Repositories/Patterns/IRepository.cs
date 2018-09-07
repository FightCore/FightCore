using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FightCore.Repositories.Patterns
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Expression<Func<TEntity, bool>> query);
        IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query);

        TEntity Insert(TEntity entity);
        IEnumerable<TEntity> InsertRange(params TEntity[] entities);

        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(params TEntity[] entities);

        void Delete(params TEntity[] keyValues);
        void Delete(TEntity entity);
    }
}
