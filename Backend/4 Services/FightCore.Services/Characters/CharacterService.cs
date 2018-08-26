using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories;
using FightCore.Repositories.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services.Characters
{
    public interface ICharacterService : IService<Character>
    {
        Task<List<Character>> GetAllCharactersAsync();
        Task<Character> GetDetailedCharacterByIdAsync(int characterId);
        Task<List<Character>> GetCharactersByGameAsync(int gameId);
    }
    public class CharacterService : Service<Character>, ICharacterService
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
            return characterId <= 0 ? null : _repository.GetDetailedCharacterByIdAsync(characterId);
        }

        public Task<List<Character>> GetCharactersByGameAsync(int gameId)
        {
            return gameId <= 0 ? null : _repository.GetAllCharactersByGameAsync(gameId);
        }
    }
}
