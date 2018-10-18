using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources.Characters;
using FightCore.Models.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services;
using FightCore.Services.Characters;
using FightCore.Services.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;
        public CharactersController(IUnitOfWorkAsync unitOfWork, ICharacterService characterService, IGameService gameService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
            _gameService = gameService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the list of characters known in FightCore.
        /// </summary>
        /// <returns>An array of simple character objects.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();

            if (!characters.Any())
            {
                return NotFound();
            }

            var resources = _mapper.Map<List<CharacterResource>>(characters);

            return Ok(resources);
        }

        /// <summary>
        /// Gets all characters based on what game they are from.
        /// </summary>
        /// <param name="gameId">The game's id within FightCore. See Games endpoint</param>
        /// <returns>
        /// 200 with an array of character objects if found
        /// 404 when there aren't any characters found for that gameId.
        /// </returns>
        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetAllCharactersForGame(int gameId)
        {
            var characters = await _characterService.GetCharactersByGameAsync(gameId);

            if (!characters.Any())
                return NotFound();

            var resources = _mapper.Map<List<CharacterResource>>(characters);

            return Ok(resources);
        }
        /// <summary>
        /// Gets the details about a specific character.
        /// </summary>
        /// <param name="id">The id of the character in question</param>
        /// <returns>
        /// 200 with a detailed character object
        /// 404 when the character with that Id is not found
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailedCharacterById(int id)
        {
            var character = await _characterService.GetDetailedCharacterByIdAsync(id);

            if (character == null)
                return NotFound();

            var resource = _mapper.Map<DetailedCharacterResource>(character);

            return Ok(resource);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Character"/> class and saves it to the database.
        /// </summary>
        /// <param name="characterResource">The resources used to create a new character</param>
        /// <returns>Where the new character can be found</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] NewCharacterResource characterResource)
        {
            var character = _mapper.Map<Character>(characterResource);
            var game = await _gameService.FindByIdAsync(characterResource.GameId);
            character.Game = game;
            await _characterService.InsertAsync(character);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetailedCharacterById), new {id = character.Id}, _mapper.Map<CharacterResource>(character));
        }
    }
}