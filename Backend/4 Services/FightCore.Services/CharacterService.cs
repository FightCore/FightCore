using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services
{
    public interface ICharacterService : IService<Character>
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetDetailedCharacterById(int characterId);
        Task<List<Character>> GetCharactersByGame(int gameId);
    }
    public class CharacterService : Service<Character>, ICharacterService
    {
        private readonly ICharacterRepository _repository;
        public CharacterService(ICharacterRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<List<Character>> GetAllCharacters()
        {
            return _repository.GetAllCharactersWithMediaAndGameAsync();
        }

        public Task<Character> GetDetailedCharacterById(int characterId)
        {
            return characterId <= 0 ? null : _repository.GetDetailedCharacterByIdAsync(characterId);
        }

        public Task<List<Character>> GetCharactersByGame(int gameId)
        {
            return gameId <= 0 ? null : _repository.GetAllCharactersByGameAsync(gameId);
        }
    }
}
