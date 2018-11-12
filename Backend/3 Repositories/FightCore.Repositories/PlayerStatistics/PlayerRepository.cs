using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.PlayerStatistics
{
    public interface IPlayerRepository : IRepositoryAsync<Player>
    {
        Task<List<Player>> GetAllPlayersWithMediaAsync();
        Task<Player> GetDetailedPlayerByIdAsync(int PlayerId);
    }
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {

        public PlayerRepository(DbContext context) : base(context)
        {
        }

        public Task<List<Player>> GetAllPlayersWithMediaAsync()
        {
            return Queryable.Include(x => x.Media).ToListAsync();
        }

        public Task<Player> GetDetailedPlayerByIdAsync(int PlayerId)
        {
            return Queryable.Include(x => x.Media)
                .Include(x => x.Sets).ThenInclude(x => x.Games)
                .Include(x => x.Sets).ThenInclude(x => x.Tournament)
                .FirstOrDefaultAsync(x => x.Id == PlayerId);
        }

    }
}
