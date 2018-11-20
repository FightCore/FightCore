using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
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

        public override Task<Set> FindByIdAsync(int SetId)
        {
            return _repository.GetDetailedSetByIdAsync(SetId);
        }

        public override Set FindById(int SetId)
        {
            return _repository.GetDetailedSetById(SetId);
        }

    }
}
