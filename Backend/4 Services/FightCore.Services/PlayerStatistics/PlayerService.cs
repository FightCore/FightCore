using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface IPlayerService : IEntityService<Player>
    {
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player> GetDetailedPlayerByIdAsync(int PlayerId);
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

        public Task<Player> GetDetailedPlayerByIdAsync(int PlayerId)
        {
            return _repository.GetDetailedPlayerByIdAsync(PlayerId);
        }

    }
}
