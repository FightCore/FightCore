using System.Collections.Generic;
using System.Threading.Tasks;

namespace FightCore.Services.Patterns
{
    public interface IService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Deletes multiple entities.
        /// </summary>
        /// <param name="entities">The entities wanting to be deleted.</param>
        void Delete(params TEntity[] entities);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">The entity wanting to be deleted.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Inserts an entity.
        /// </summary>
        /// <param name="entity">The entity wanting to be inserted.</param>
        /// <returns>The inserted and tracked entity.</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Inserts a entity.
        /// </summary>
        /// <param name="entity">The entity wanting to be inserted.</param>
        /// <returns>An awaitable task with the result being the inserted and tracked entity.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Inserts a range of entities.
        /// </summary>
        /// <param name="entities">The entities wanting to be inserted.</param>
        /// <returns>A collection of entities that have been inserted and being tracked.</returns>
        IEnumerable<TEntity> InsertRange(params TEntity[] entities);

        /// <summary>
        /// Inserts a range of entities.
        /// </summary>
        /// <param name="entities">The entities wanting to be inserted.</param>
        /// <returns>An awaitable task with the result being a collection of entities that have been inserted and being tracked.</returns>
        Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity wanting to be updated.</param>
        /// <returns>The updated entity.</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Updates a range of entities.
        /// </summary>
        /// <param name="entities">The entities wanting to be updated.</param>
        /// <returns>A collection of updated and tracked entities.</returns>
        IEnumerable<TEntity> UpdateRange(params TEntity[] entities);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>An awaitable task with the result being a collection of all entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
