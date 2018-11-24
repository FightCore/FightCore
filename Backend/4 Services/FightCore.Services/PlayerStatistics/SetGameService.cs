using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Generic Entity Service interface for the SetGame Entity
    /// </summary>
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

        public override Task<SetGame> FindByIdAsync(int setGameId)
        {
            return _repository.GetDetailedSetGameByIdAsync(setGameId);
        }

        public override SetGame FindById(int setGameId)
        {
            return _repository.GetDetailedSetGameById(setGameId);
        }

    }
}
