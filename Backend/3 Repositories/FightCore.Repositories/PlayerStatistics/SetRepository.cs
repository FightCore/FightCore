using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.PlayerStatistics
{
    /// <summary>
    /// Repository interface for Entity <see cref="FightCore.Models.PlayerStatistics.Set"/>
    /// </summary>
    public interface ISetRepository : IRepositoryAsync<Set>
    {
        Task<Set> GetDetailedSetByIdAsync(int setId);
        Set GetDetailedSetById(int setId);
    }

    public class SetRepository : Repository<Set>, ISetRepository
    {

        public SetRepository(DbContext context) : base(context)
        {
        }

        public Task<Set> GetDetailedSetByIdAsync(int setId)
        {
            return Queryable
                .Include(x => x.Games).ThenInclude(x => x.Character1)
                .Include(x => x.Games).ThenInclude(x => x.Character2)
                .Include(x => x.Tournament)
                .Include(x => x.Event)
                .Include(x => x.Winner)
                .Include(x => x.Loser)
                .FirstOrDefaultAsync(x => x.Id == setId);
        }

        public Set GetDetailedSetById(int setId)
        {
            return Queryable
                .Include(x => x.Games).ThenInclude(x => x.Character1)
                .Include(x => x.Games).ThenInclude(x => x.Character2)
                .Include(x => x.Tournament)
                .Include(x => x.Event)
                .Include(x => x.Winner)
                .Include(x => x.Loser)
                .FirstOrDefault(x => x.Id == setId);
        }

    }
}
