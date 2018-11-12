using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.PlayerStatistics
{
    public interface ITournamentRepository : IRepositoryAsync<Tournament>
    {
        Task<List<Tournament>> GetAllTournamentsWithMediaAsync();
        Task<Tournament> GetDetailedTournamentByIdAsync(int TournamentId);
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

        public Task<Tournament> GetDetailedTournamentByIdAsync(int TournamentId)
        {
            return Queryable
                .Include(x => x.Medias)
                .FirstOrDefaultAsync(x => x.Id == TournamentId);
        }

    }
}
