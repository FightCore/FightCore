using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Repositories.Games;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services.Games
{
    public interface IGameService : IService<Game>
    {
        Task<List<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
    }
    public class GameService : Service<Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository) : base(gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<List<Game>> GetAllGamesAsync()
        {
            return _gameRepository.GetAllGamesAsync();
        }

        public Task<Game> GetGameByIdAsync(int id)
        {
            return _gameRepository.GetGameByIdAsync(id);
        }
    }
}
