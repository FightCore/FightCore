using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Repositories.Patterns;

namespace FightCore.Services.Patterns
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepositoryAsync<TEntity> _techniqueRepository;

        public Service(IRepositoryAsync<TEntity> techniqueRepository)
        {
            _techniqueRepository = techniqueRepository;
        }

        public void Delete(params TEntity[] entities) => _techniqueRepository.Delete(entities);

        public void Delete(TEntity entity) => _techniqueRepository.Delete(entity);

        public TEntity Insert(TEntity entity) => _techniqueRepository.Insert(entity);

        public Task<TEntity> InsertAsync(TEntity entity) => _techniqueRepository.InsertAsync(entity);

        public IEnumerable<TEntity> InsertRange(params TEntity[] entities) => _techniqueRepository.InsertRange(entities);

        public Task<IEnumerable<TEntity>> InsertRangeAsync(params TEntity[] entities) => _techniqueRepository.InsertRangeAsync(entities);

        public TEntity Update(TEntity entity) => _techniqueRepository.Update(entity);

        public IEnumerable<TEntity> UpdateRange(params TEntity[] entities) => _techniqueRepository.UpdateRange(entities);

        public Task<IEnumerable<TEntity>> GetAllAsync() => _techniqueRepository.GetAllAsync();
    }
}
