using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources.Characters;
using FightCore.Services;
using FightCore.Services.Characters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;
        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();

            if (!characters.Any())
            {
                return BadRequest();
            }

            var resources = _mapper.Map<List<CharacterResource>>(characters);

            return Ok(resources);
        }

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetAllCharactersForGame(int gameId)
        {
            var characters = await _characterService.GetCharactersByGameAsync(gameId);

            if (!characters.Any())
                return BadRequest();

            var resources = _mapper.Map<List<CharacterResource>>(characters);

            return Ok(resources);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetDetailedCharacterById(int id)
        {
            var character = await _characterService.GetDetailedCharacterByIdAsync(id);

            if (character == null)
                return BadRequest();

            var resource = _mapper.Map<DetailedCharacterResource>(character);

            return Ok(resource);
        }
    }
}