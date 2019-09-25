using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories.Helper.Queryable;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Characters
{
    public interface ICharacterRepository : IRepositoryAsync<Character>
    {
        Task<List<Character>> GetAllCharactersWithMediaAndGameAsync();

        Task<Character> GetDetailedCharacterByIdAsync(int characterId);

        Task<List<Character>> GetAllCharactersByIdsAsync(IEnumerable<int> ids);

        Task<List<Character>> GetAllCharactersByGameAsync(int gameId);

        Task<List<Character>> GetCharactersByNameAsync(string name);
    }
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(DbContext context) : base(context)
        {
        }

        public Task<List<Character>> GetAllCharactersWithMediaAndGameAsync()
        {
            return Queryable.IncludeBasic().ToListAsync();
        }

        public Task<Character> GetDetailedCharacterByIdAsync(int characterId)
        {
            return Queryable.IncludeExpanded().FirstOrDefaultAsync(x => x.Id == characterId);
        }

        public Task<List<Character>> GetAllCharactersByIdsAsync(IEnumerable<int> ids)
        {
            return Queryable.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public Task<List<Character>> GetAllCharactersByGameAsync(int gameId)
        {
            return Queryable.IncludeBasic().Where(x => x.Game.Id == gameId).ToListAsync();
        }

        public Task<List<Character>> GetCharactersByNameAsync(string name)
        {
            return Queryable.IncludeBasic().Where(x => x.Name.Contains(name)).ToListAsync();
        }
    }
}
