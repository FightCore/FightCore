using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources.Games;
using Microsoft.AspNetCore.Mvc;
using FightCore.Services.Games;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GameService _gameService;

        private IMapper _mapper;

        public GamesController(GameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all the games known to FightCore
        /// </summary>
        /// <returns>
        /// 200: A list of game objects.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var games = await _gameService.GetAllGamesAsync();

            var mappedGames = _mapper.Map<List<GameResource>>(games);

            return Ok(mappedGames);
        }

        /// <summary>
        /// Gets a specific game based on its id
        /// </summary>
        /// <param name="id">The id of the game wanting to be gotten</param>
        /// <returns>
        /// 200: One simple game object
        /// 400: Id is bellow 1
        /// 404: Object with that Id is not found
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameByIdAsync(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var game = await _gameService.FindByIdAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            var mappedGame = _mapper.Map<GameResource>(game);

            return Ok(mappedGame);
        }

        /// <summary>
        /// Searches for the game based on the given name.
        /// Game's name may also just contain the given name.
        /// Game's abbreviation will also be checked.
        /// </summary>
        /// <param name="name">The name wanting to be searched for.</param>
        /// <returns>
        /// 200: An array of game objects.
        /// 404: No game with that name or abbreviation is found.
        /// 400: Name is null or whitespace
        /// </returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetGameByName(string name)
        {
            return Ok();
        }
    }
}