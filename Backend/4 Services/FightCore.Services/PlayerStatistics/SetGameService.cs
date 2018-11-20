using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface ISetGameService : IEntityService<SetGame>
    {

    }
    public class SetGameService : EntityService<SetGame>, ISetGameService
    {
        private readonly ISetGameRepository _repository;
        public SetGameService(ISetGameRepository repository) : base((IRepositoryAsync<SetGame>)repository)
        {
            _repository = repository;
        }

        public override Task<SetGame> FindByIdAsync(int SetGameId)
        {
            return _repository.GetDetailedSetGameByIdAsync(SetGameId);
        }

        public override SetGame FindById(int SetGameId)
        {
            return _repository.GetDetailedSetGameById(SetGameId);
        }

    }
}
