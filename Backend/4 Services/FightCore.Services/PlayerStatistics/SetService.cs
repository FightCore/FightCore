using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Entity Service interface for Entity <see cref="FightCore.Models.PlayerStatistics.Set"/>
    /// </summary>
    public interface ISetService : IEntityService<Set>
    {
    }

    public class SetService : EntityService<Set>, ISetService
    {
        private readonly ISetRepository _repository;
        public SetService(ISetRepository repository) : base((IRepositoryAsync<Set>)repository)
        {
            _repository = repository;
        }

        public override Task<Set> FindByIdAsync(int id)
        {
            return _repository.GetDetailedSetByIdAsync(id);
        }

        public override Set FindById(int id)
        {
            return _repository.GetDetailedSetById(id);
        }

    }
}
