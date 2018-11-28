using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Entity Service interface for Entity <see cref="FightCore.Models.PlayerStatistics.SetGame"/>
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

        public override Task<SetGame> FindByIdAsync(int id)
        {
            return _repository.GetDetailedSetGameByIdAsync(id);
        }

        public override SetGame FindById(int id)
        {
            return _repository.GetDetailedSetGameById(id);
        }

    }
}
