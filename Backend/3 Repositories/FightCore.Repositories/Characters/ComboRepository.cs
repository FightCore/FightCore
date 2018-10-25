using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FightCore.Models.Characters;
using FightCore.Repositories.Helper.Queryable;
using FightCore.Repositories.Patterns;

using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Characters
{
    public interface IComboRepository : IRepositoryAsync<Combo>
    {
        Task<List<Combo>> GetAllCombosAsync();

        Task<Combo> GetComboByIdAsync(int id);

        Task<List<Combo>> GetCombosByGameIdAsync(int gameId);

        Task<List<Combo>> GetCombosByCharacterId(int characterId);

        Task<List<Combo>> GetCombosByNameAsync(string name);
    }

    public class ComboRepository : Repository<Combo>, IComboRepository
    {
        public ComboRepository(DbContext context)
            : base(context)
        {
        }

        public Task<List<Combo>> GetAllCombosAsync()
        {
            return Queryable.IncludeBasic().ToListAsync();
        }

        public Task<Combo> GetComboByIdAsync(int id)
        {
            return Queryable.IncludeExpanded().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Combo>> GetCombosByGameIdAsync(int gameId)
        {
            return Queryable.IncludeBasic().Where(x => x.Performers.FirstOrDefault(y => y.Character.Game.Id == gameId) != null).ToListAsync();
        }

        public Task<List<Combo>> GetCombosByCharacterId(int characterId)
        {
            return Queryable.IncludeBasic().Where(x => x.Performers.FirstOrDefault(y => y.CharacterId == characterId) != null).ToListAsync();
        }

        public Task<List<Combo>> GetCombosByNameAsync(string name)
        {
            return Queryable.IncludeBasic().Where(x => x.Name.Contains(name)).ToListAsync();
        }
    }
}