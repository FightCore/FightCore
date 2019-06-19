using FightCore.Models;
using System;
using System.Threading.Tasks;
using FightCore.Repositories.Patterns;

namespace FightCore.Services.Patterns
{
    public interface IEntityService<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Finds an entity by it's id.
        /// </summary>
        /// <param name="id">The id wanting to be searched for.</param>
        /// <returns>An awaitable task with the result being the entity.</returns>
        Task<TEntity> FindByIdAsync(int id);

        /// <summary>
        /// Finds the entity by it's id.
        /// </summary>
        /// <param name="id">The id wanting to be searched for.</param>
        /// <returns>An entity.</returns>
        TEntity FindById(int id);

        /// <summary>
        /// Deletes an entity by it's id.
        /// </summary>
        /// <param name="id">The id of the entity wanting to be deleted.</param>
        /// <returns>An awaitable task.</returns>
        Task DeleteByIdAsync(int id);

        /// <summary>
        /// Deletes an entity by it's id.
        /// </summary>
        /// <param name="id">The id of the entity wanting to be deleted.</param>
        void DeleteById(int id);
    }

    public abstract class EntityService<TEntity> : Service<TEntity>, IEntityService<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityService{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository wanting to be used.</param>
        protected EntityService(IRepositoryAsync<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public virtual Task<TEntity> FindByIdAsync(int id)
        {
            return _repository.FindAsync(a => a.Id.Equals(id));
        }

        /// <inheritdoc />
        public virtual TEntity FindById(int id)
        {
            return _repository.Find(a => a.Id.Equals(id));
        }

        /// <inheritdoc />
        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException(nameof(id));
            }

            Delete(entity);
        }

        /// <inheritdoc />
        public virtual void DeleteById(int id)
        {
            var entity = FindById(id);
            if (entity == null)
            {
                throw new ArgumentException(nameof(id));
            }

            Delete(entity);
        }
    }
}
