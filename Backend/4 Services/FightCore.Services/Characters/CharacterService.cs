using System.Collections.Generic;
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
        Task<Character> GetDetailedCharacterByIdAsync(int characterId);
        Task<List<Character>> GetCharactersByGameAsync(int gameId);
    }
    public class CharacterService : EntityService<Character>, ICharacterService
    {
        private readonly ICharacterRepository _repository;
        public CharacterService(ICharacterRepository repository) : base((IRepositoryAsync<Character>) repository)
        {
            _repository = repository;
        }

        public Task<List<Character>> GetAllCharactersAsync()
        {
            return _repository.GetAllCharactersWithMediaAndGameAsync();
        }

        public Task<Character> GetDetailedCharacterByIdAsync(int characterId)
        {
            return _repository.GetDetailedCharacterByIdAsync(characterId);
        }

        
        public Task<List<Character>> GetCharactersByGameAsync(int gameId)
        {
            return _repository.GetAllCharactersByGameAsync(gameId);
        }
    }
}
