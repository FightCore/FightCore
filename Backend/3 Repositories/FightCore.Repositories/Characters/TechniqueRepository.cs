using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Characters
{
    public interface ITechniqueRepository : IRepositoryAsync<Technique>
    {
        Task<List<Technique>> GetTechniquesAsync();
        Task<List<Technique>> GetTechniquesByGameAsync(int gameId);
        Task<Technique> GetTechniqueByIdAsync(int id);
    }
    public class TechniqueRepository : Repository<Technique>, ITechniqueRepository
    {
        public TechniqueRepository(DbContext context) : base(context)
        {
        }

        public Task<List<Technique>> GetTechniquesAsync()
        {
            return Queryable.Include(x => x.Media).Include(x => x.Game).ToListAsync();
        }

        public Task<List<Technique>> GetTechniquesByGameAsync(int gameId)
        {
            return Queryable.Include(x => x.Media).Include(x => x.Game).Where(x=>x.Game.Id == gameId).ToListAsync();
        }

        public Task<Technique> GetTechniqueByIdAsync(int id)
        {
            return Queryable.Include(x => x.Inputs).Include(x => x.Media).Include(x => x.Game).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
