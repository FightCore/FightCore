using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories;
using FightCore.Repositories.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services.Characters
{
    public interface ICharacterService : IEntityService<Character>
    {
        Task<List<Character>> GetAllCharactersAsync();

        Task<List<Character>> GetAllCharactersByIdsAsync(IEnumerable<int> ids);

        Task<List<Character>> GetCharactersByGameAsync(int gameId);

        Task<List<Character>> GetCharactersByNameAsync(string name);
    }

    public class CharacterService : EntityService<Character>, ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<List<Character>> GetAllCharactersAsync()
        {
            return _repository.GetAllCharactersWithMediaAndGameAsync();
        }

        public Task<List<Character>> GetAllCharactersByIdsAsync(IEnumerable<int> ids)
        {
            return _repository.GetAllCharactersByIdsAsync(ids);
        }

        public override Task<Character> FindByIdAsync(int id)
        {
            return _repository.GetDetailedCharacterByIdAsync(id);
        }

        public Task<List<Character>> GetCharactersByGameAsync(int gameId)
        {
            return _repository.GetAllCharactersByGameAsync(gameId);
        }

        public Task<List<Character>> GetCharactersByNameAsync(string name)
        {
            return _repository.GetCharactersByNameAsync(name);
        }
    }
}
