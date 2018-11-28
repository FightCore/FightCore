using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Entity Service interface for Entity <see cref="Player"/>
    /// </summary>
    public interface IPlayerService : IEntityService<Player>
    {
        Task<List<Player>> GetAllPlayersAsync();
    }

    public class PlayerService : EntityService<Player>, IPlayerService
    {
        private readonly IPlayerRepository _repository;
        public PlayerService(IPlayerRepository repository) : base((IRepositoryAsync<Player>)repository)
        {
            _repository = repository;
        }

        public Task<List<Player>> GetAllPlayersAsync()
        {
            return _repository.GetAllPlayersWithMediaAsync();
        }

        public override Task<Player> FindByIdAsync(int id)
        {
            return _repository.GetDetailedPlayerByIdAsync(id);
        }

        public override Player FindById(int id)
        {
            return _repository.GetDetailedPlayerById(id);
        }

    }
}
