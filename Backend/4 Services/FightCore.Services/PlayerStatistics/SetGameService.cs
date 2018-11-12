using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface ISetGameService : IEntityService<SetGame>
    {
        Task<SetGame> GetDetailedSetGameByIdAsync(int SetGameId);
    }
    public class SetGameService : EntityService<SetGame>, ISetGameService
    {
        private readonly ISetGameRepository _repository;
        public SetGameService(ISetGameRepository repository) : base((IRepositoryAsync<SetGame>)repository)
        {
            _repository = repository;
        }

        public Task<SetGame> GetDetailedSetGameByIdAsync(int SetGameId)
        {
            return _repository.GetDetailedSetGameByIdAsync(SetGameId);
        }

    }
}
