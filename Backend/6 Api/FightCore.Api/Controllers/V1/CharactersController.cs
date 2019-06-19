using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources.Characters;
using FightCore.Services.Characters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FightCore.Api.Controllers.V1
{
    using Swashbuckle.AspNetCore.Annotations;

    /// <inheritdoc />
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CharactersController : Controller
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all characters known in FightCore
        /// </summary>
        /// <returns>A list of characters</returns>
        [HttpGet]
        [SwaggerResponse(200, type: typeof(CharacterResource))]
        public async Task<IActionResult> GetAll()
        {
            var characters = await _characterService.GetAllAsync();

            var mappedCharacters = _mapper.Map<List<CharacterResource>>(characters);

            return Ok(mappedCharacters);
        }

        /// <summary>
        /// Gets a character based on it's id.
        /// </summary>
        /// <returns>A character object.</returns>
        [HttpGet("{id}")]
        [SwaggerResponse(200, type: typeof(CharacterResource))]
        public async Task<IActionResult> Get(int id)
        {
            var character = await _characterService.FindByIdAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            var mappedCharacter = _mapper.Map<CharacterResource>(character);

            return Ok(mappedCharacter);
        }

        /// <summary>
        /// Gets all posts about a character by it's id.
        /// </summary>
        /// <param name="id">The character's id.</param>
        /// <returns>A list of posts.</returns>
        [HttpGet("posts/{id}")]
        public async Task<IActionResult> GetPosts(int id)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}