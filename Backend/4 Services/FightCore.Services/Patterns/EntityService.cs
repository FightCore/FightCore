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
        private readonly IRepositoryAsync<TEntity> _techniqueRepository;

        protected EntityService(IRepositoryAsync<TEntity> techniqueRepository) : base(techniqueRepository)
        {
            _techniqueRepository = techniqueRepository;
        }

        public virtual Task<TEntity> FindByIdAsync(int id)
        {
            return _techniqueRepository.FindAsync(a => a.Id.Equals(id));
        }

        public virtual TEntity FindById(int id)
        {
            return _techniqueRepository.Find(a => a.Id.Equals(id));
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity == null)
                throw new ArgumentException(nameof(id));
            
            Delete(entity);
        }

        public virtual void DeleteById(int id)
        {
            var entity = FindById(id);
            if (entity == null)
                throw new ArgumentException(nameof(id));

            Delete(entity);
        }
    }
}
