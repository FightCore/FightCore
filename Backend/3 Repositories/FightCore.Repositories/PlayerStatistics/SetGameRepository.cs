using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.PlayerStatistics
{
    public interface ISetGameRepository : IRepositoryAsync<SetGame>
    {
        Task<SetGame> GetDetailedSetGameByIdAsync(int SetGameId);
    }

    public class SetGameRepository : Repository<SetGame>, ISetGameRepository
    {

        public SetGameRepository(DbContext context) : base(context)
        {
        }

        public Task<SetGame> GetDetailedSetGameByIdAsync(int SetGameId)
        {
            return Queryable.Include(x => x.Character1).Include(x => x.Character2)
                .Include(x => x.Set).ThenInclude(x => x.Tournament)
                .Include(x => x.Set).ThenInclude(x => x.Event)
                .FirstOrDefaultAsync(x => x.Id == SetGameId);
        }

    }
}
