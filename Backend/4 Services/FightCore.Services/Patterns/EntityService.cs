using FightCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FightCore.Repositories.Patterns;

namespace FightCore.Services.Patterns
{
    public interface IEntityService<TEntity> : IService<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> FindByIdAsync(int id);
        TEntity FindById(int id);
        Task DeleteByIdAsync(int id);
        void DeleteById(int id);
    }

    public abstract class EntityService<TEntity> : Service<TEntity>, IEntityService<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepositoryAsync<TEntity> _repository;

        protected EntityService(IRepositoryAsync<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<TEntity> FindByIdAsync(int id)
        {
            return _repository.FindAsync(a => a.Id.Equals(id));
        }

        public TEntity FindById(int id)
        {
            return _repository.Find(a => a.Id.Equals(id));
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity == null)
                throw new ArgumentException(nameof(id));
            
            Delete(entity);
        }

        public void DeleteById(int id)
        {
            var entity = FindById(id);
            if (entity == null)
                throw new ArgumentException(nameof(id));

            Delete(entity);
        }
    }
}
