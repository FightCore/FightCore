using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Repositories.Patterns;

namespace FightCore.Services.Patterns
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        public Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        public void Delete(params TEntity[] entities) => _repository.Delete(entities);

        public void Delete(TEntity entity) => _repository.Delete(entity);

        public TEntity Insert(TEntity entity) => _repository.Insert(entity);

        public Task<TEntity> InsertAsync(TEntity entity) => _repository.InsertAsync(entity);

        public IEnumerable<TEntity> InsertRange(params TEntity[] entities) => _repository.InsertRange(entities);

        public Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities) => _repository.InsertRangeAsync(entities);

        public TEntity Update(TEntity entity) => _repository.Update(entity);

        public IEnumerable<TEntity> UpdateRange(params TEntity[] entities) => _repository.UpdateRange(entities);

        public Task<IEnumerable<TEntity>> GetAllAsync() => _repository.GetAllAsync();
    }
}
