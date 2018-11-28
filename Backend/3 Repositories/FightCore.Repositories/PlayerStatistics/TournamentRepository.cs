using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.PlayerStatistics
{
    /// <summary>
    /// Repository interface for Entity <see cref="FightCore.Models.PlayerStatistics.Tournament"/>
    /// </summary>
    public interface ITournamentRepository : IRepositoryAsync<Tournament>
    {
        Task<List<Tournament>> GetAllTournamentsWithMediaAsync();
        Task<Tournament> GetDetailedTournamentByIdAsync(int tournamentId);
        Tournament GetDetailedTournamentById(int tournamentId);
    }

    public class TournamentRepository : Repository<Tournament>, ITournamentRepository
    {

        public TournamentRepository(DbContext context) : base(context)
        {
        }

        public Task<List<Tournament>> GetAllTournamentsWithMediaAsync()
        {
            return Queryable.Include(x => x.Medias).ToListAsync();
        }

        public Task<Tournament> GetDetailedTournamentByIdAsync(int tournamentId)
        {
            return Queryable
                .Include(x => x.Medias)
                .FirstOrDefaultAsync(x => x.Id == tournamentId);
        }

        public Tournament GetDetailedTournamentById(int tournamentId)
        {
            return Queryable
                .Include(x => x.Medias)
                .FirstOrDefault(x => x.Id == tournamentId);
        }

    }
}
