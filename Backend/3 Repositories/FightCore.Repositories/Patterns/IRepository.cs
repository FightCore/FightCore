using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FightCore.Repositories.Patterns
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets <typeparamref name="TEntity"/> based on the provided <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The query wanting to be executed.</param>
        /// <returns>An instance of the <typeparamref name="TEntity"/> class.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Gets a range of <typeparamref name="TEntity"/> based on the provided <paramref name="query"/>
        /// </summary>
        /// <param name="query">The query wanting to be executed.</param>
        /// <returns>A collection of <typeparamref name="TEntity"/> objects.</returns>
        IEnumerable<TEntity> FindRange(Expression<Func<TEntity, bool>> query);

        /// <summary>
        /// Inserts a <typeparamref name="TEntity"/> object into the context.
        /// </summary>
        /// <param name="entity">The entity wanting to be inserted.</param>
        /// <returns>An instance of the <typeparamref name="TEntity"/> class.</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Inserts a collection of entities.
        /// </summary>
        /// <param name="entities">The entities wanting to be inserted.</param>
        /// <returns></returns>
        IEnumerable<TEntity> InsertRange(params TEntity[] entities);

        /// <summary>
        /// Updates a <typeparamref name="TEntity"/> object into the context.
        /// </summary>
        /// <param name="entity">The entity wanting to be updated.</param>
        /// <returns>An instance of the <typeparamref name="TEntity"/> class.</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Updates a collection of <typeparamref name="TEntity"/> objects into the context.
        /// </summary>
        /// <param name="entities">The entities wanting to be updated.</param>
        /// <returns>An collection of the <typeparamref name="TEntity"/> class.</returns>
        IEnumerable<TEntity> UpdateRange(params TEntity[] entities);

        /// <summary>
        /// Deletes the values from the context.
        /// </summary>
        /// <param name="keyValues">The entities wanting to be deleted.</param>
        void Delete(params TEntity[] keyValues);

        /// <summary>
        /// Deletes an entity from the context.
        /// </summary>
        /// <param name="entity">The entity wanting to be deleted.</param>
        void Delete(TEntity entity);
    }
}
