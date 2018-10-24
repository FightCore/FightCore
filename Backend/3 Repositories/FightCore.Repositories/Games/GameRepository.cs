using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Repositories.Helper.Queryable;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Games
{
    public interface IGameRepository : IRepositoryAsync<Game>
    {
        Game GetGameById(int id);

        Task<Game> GetGameByIdAsync(int id);

        Task<List<Game>> GetAllGamesAsync();
    }

    public class GameRepository: Repository<Game>, IGameRepository
    {
        public GameRepository(DbContext context) : base(context)
        {
        }

        public Game GetGameById(int id)
        {
            return Queryable.IncludeMedia().FirstOrDefault(x => x.Id == id);
        }

        public Task<Game> GetGameByIdAsync(int id)
        {
            return Queryable.IncludeMedia().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Game>> GetAllGamesAsync()
        {
            return Queryable.IncludeMedia().ToListAsync();
        }
    }
}
