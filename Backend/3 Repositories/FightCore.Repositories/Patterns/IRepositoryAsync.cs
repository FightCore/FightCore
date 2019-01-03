using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FightCore.Repositories.Patterns
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Finds an entity based on the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query wanting to be executed.</param>
        /// <returns>An awaitable task with the result the entity.</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Finds an collection of entities based on the given <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query wanting to be executed.</param>
        /// <returns>An awaitable task with the result a collection of entities.</returns>
        Task<IEnumerable<TEntity>> FindRangeAsync(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Inserts an entity into the context.
        /// </summary>
        /// <param name="entity">The entity wanting to be inserted.</param>
        /// <returns>An awaitable task with the result being an inserted entity.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Inserts a range of entities into context.
        /// </summary>
        /// <param name="entities">The entities wanting to be inserted.</param>
        /// <returns>An awaitable task with the result being a collection of inserted entities.</returns>
        Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>An awaitable task with the result being a collection of entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
