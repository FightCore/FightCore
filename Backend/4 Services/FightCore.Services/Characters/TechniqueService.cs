using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services.Characters
{
    public interface ITechniqueService : IService<Technique>
    {
        Task<List<Technique>> GetTechniquesAsync();
        Task<List<Technique>> GetTechniquesByGameAsync(int gameId);
        Task<Technique> GetTechniqueByIdAsync(int id);
    }
    public class TechniqueService : Service<Technique>, ITechniqueService
    {
        private readonly ITechniqueRepository _techniqueRepository;
        public TechniqueService(ITechniqueRepository techniqueRepository) : base(techniqueRepository)
        {
            _techniqueRepository = techniqueRepository;
        }

        public Task<List<Technique>> GetTechniquesAsync()
        {
            return _techniqueRepository.GetTechniquesAsync();
        }

        public Task<List<Technique>> GetTechniquesByGameAsync(int gameId)
        {
            return gameId <= 0 ? null : _techniqueRepository.GetTechniquesByGameAsync(gameId);
        }

        public Task<Technique> GetTechniqueByIdAsync(int id)
        {
            return id <= 0 ? null : _techniqueRepository.GetTechniqueByIdAsync(id);
        }
    }
}
