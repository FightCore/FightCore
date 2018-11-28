using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.PlayerStatistics
{
    /// <summary>
    /// Repository interface for Entity <see cref="SetGame"/>
    /// </summary>
    public interface ISetGameRepository : IRepositoryAsync<SetGame>
    {
        Task<SetGame> GetDetailedSetGameByIdAsync(int setGameId);
        SetGame GetDetailedSetGameById(int setGameId);
    }

    public class SetGameRepository : Repository<SetGame>, ISetGameRepository
    {

        public SetGameRepository(DbContext context) : base(context)
        {
        }

        public Task<SetGame> GetDetailedSetGameByIdAsync(int setGameId)
        {
            return Queryable.Include(x => x.Character1).Include(x => x.Character2)
                .Include(x => x.Set).ThenInclude(x => x.Tournament)
                .Include(x => x.Set).ThenInclude(x => x.Event)
                .FirstOrDefaultAsync(x => x.Id == setGameId);
        }

        public SetGame GetDetailedSetGameById(int setGameId)
        {
            return Queryable.Include(x => x.Character1).Include(x => x.Character2)
                .Include(x => x.Set).ThenInclude(x => x.Tournament)
                .Include(x => x.Set).ThenInclude(x => x.Event)
                .FirstOrDefault(x => x.Id == setGameId);
        }

    }
}
