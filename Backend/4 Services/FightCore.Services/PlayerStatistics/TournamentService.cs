﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
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

        public override Task<Tournament> FindByIdAsync(int TournamentId)
        {
            return _repository.GetDetailedTournamentByIdAsync(TournamentId);
        }

        public override Tournament FindById(int TournamentId)
        {
            return _repository.GetDetailedTournamentById(TournamentId);
        }

    }
}