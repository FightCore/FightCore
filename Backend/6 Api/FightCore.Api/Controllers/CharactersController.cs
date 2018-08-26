using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharacters();

            if (!characters.Any())
            {
                return BadRequest();
            }

            return Ok(characters);
        }

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetAllCharactersForGame(int gameId)
        {
            var characters = await _characterService.GetCharactersByGame(gameId);

            if (!characters.Any())
                return BadRequest();

            return Ok(characters);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetDetailedCharacterById(int id)
        {
            var character = await _characterService.GetDetailedCharacterById(id);

            if (character == null)
                return BadRequest();

            return Ok(character);
        }
    }
}