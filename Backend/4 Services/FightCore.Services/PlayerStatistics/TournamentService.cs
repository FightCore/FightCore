using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Entity Service interface for Entity <see cref="FightCore.Models.PlayerStatistics.Tournament"/>
    /// </summary>
    public interface ITournamentService : IEntityService<Tournament>
    {
        Task<List<Tournament>> GetAllTournamentsAsync();
    }

    public class TournamentService : EntityService<Tournament>, ITournamentService
    {
        private readonly ITournamentRepository _repository;
        public TournamentService(ITournamentRepository repository) : base((IRepositoryAsync<Tournament>)repository)
        {
            _repository = repository;
        }

        public Task<List<Tournament>> GetAllTournamentsAsync()
        {
            return _repository.GetAllTournamentsWithMediaAsync();
        }

        public override Task<Tournament> FindByIdAsync(int id)
        {
            return _repository.GetDetailedTournamentByIdAsync(id);
        }

        public override Tournament FindById(int id)
        {
            return _repository.GetDetailedTournamentById(id);
        }

    }
}
