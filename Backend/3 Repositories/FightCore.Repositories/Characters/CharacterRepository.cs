using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;
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
            return EntityFrameworkQueryableExtensions.Include<Character, List<Media>>(Queryable, x=>x.Media).Include(x=>x.Game).ToListAsync();
        }

        public Task<Character> GetDetailedCharacterByIdAsync(int characterId)
        {
            return EntityFrameworkQueryableExtensions.Include<Character, Game>(Queryable, x => x.Game).Include(x => x.Media).Include(x=>x.Techniques).FirstOrDefaultAsync(x => x.Id == characterId);
        }

        public Task<List<Character>> GetAllCharactersByGameAsync(int gameId)
        {
            return EntityFrameworkQueryableExtensions.Include<Character, List<Media>>(Queryable, x => x.Media).Where(x => x.Game.Id == gameId).ToListAsync();
        }
    }
}
