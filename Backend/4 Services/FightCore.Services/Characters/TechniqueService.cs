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
    public interface ITechniqueService : IEntityService<Technique>
    {
        Task<List<Technique>> GetTechniquesAsync();

        Task<List<Technique>> GetTechniquesByGameAsync(int gameId);

        Task<List<Technique>> GetTechniqueContainingNameAsync(string name);
    }
    public class TechniqueService : EntityService<Technique>, ITechniqueService
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

        public Task<List<Technique>> GetTechniqueContainingNameAsync(string name)
        {
            return _techniqueRepository.GetTechniqueContainingNameAsync(name);
        }

        public Task<List<Technique>> GetTechniquesByGameAsync(int gameId)
        {
            return _techniqueRepository.GetTechniquesByGameAsync(gameId);
        }

        public override Technique FindById(int id)
        {
            return _techniqueRepository.GetTechniqueById(id);
        }

        public override Task<Technique> FindByIdAsync(int id)
        {
            return _techniqueRepository.GetTechniqueByIdAsync(id);
        }
    }
}
