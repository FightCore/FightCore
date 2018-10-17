using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Characters
{
    public interface ICharacterRepository : IRepositoryAsync<Character>
    {
        Task<List<Character>> GetAllCharactersWithMediaAndGameAsync();
        Task<Character> GetDetailedCharacterByIdAsync(int characterId);
        Task<List<Character>> GetAllCharactersByGameAsync(int gameId);
    }
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(DbContext context) : base(context)
        {
        }

        public Task<List<Character>> GetAllCharactersWithMediaAndGameAsync()
        {
            return Queryable.Include(x => x.Media).Include(x => x.Game).ToListAsync();
        }

        public Task<Character> GetDetailedCharacterByIdAsync(int characterId)
        {
            return Queryable.Include(x => x.Game).Include(x => x.Media)
                //TODO Import techniques with the model
                .Include(x => x.Combos).ThenInclude(x => x.Inputs).ThenInclude(x => x.Technique)
                .Include(x => x.Combos).ThenInclude(x => x.Inputs).ThenInclude(x => x.Move)
                .Include(x => x.Combos).ThenInclude(x => x.Inputs).ThenInclude(x => x.Input)
                .Include(x => x.Moves).ThenInclude(x => x.Media).FirstOrDefaultAsync(x => x.Id == characterId);
        }

        public Task<List<Character>> GetAllCharactersByGameAsync(int gameId)
        {
            return Queryable.Include(x => x.Media).Where(x => x.Game.Id == gameId).ToListAsync();
        }
    }
}
