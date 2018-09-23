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
    public interface IGameService : IEntityService<Game>
    {
        Task<List<Game>> GetAllGamesAsync();
    }
    public class GameService : EntityService<Game>, IGameService
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

        public override Game FindById(int id)
        {
            return _gameRepository.GetGameById(id);
        }

        public override Task<Game> FindByIdAsync(int id)
        {
            return _gameRepository.GetGameByIdAsync(id);
        }

    }
}
