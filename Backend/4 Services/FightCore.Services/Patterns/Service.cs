using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Repositories.Patterns;

namespace FightCore.Services.Patterns
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">The repository wanting to be used.</param>
        public Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public void Delete(params TEntity[] entities) => _repository.Delete(entities);

        /// <inheritdoc />
        public void Delete(TEntity entity) => _repository.Delete(entity);

        /// <inheritdoc />
        public TEntity Insert(TEntity entity) => _repository.Insert(entity);

        /// <inheritdoc />
        public Task<TEntity> InsertAsync(TEntity entity) => _repository.InsertAsync(entity);

        /// <inheritdoc />
        public IEnumerable<TEntity> InsertRange(params TEntity[] entities) => _repository.InsertRange(entities);

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities) => _repository.InsertRangeAsync(entities);

        /// <inheritdoc />
        public TEntity Update(TEntity entity) => _repository.Update(entity);

        /// <inheritdoc />
        public IEnumerable<TEntity> UpdateRange(params TEntity[] entities) => _repository.UpdateRange(entities);

        /// <inheritdoc />
        public Task<IEnumerable<TEntity>> GetAllAsync() => _repository.GetAllAsync();
    }
}
