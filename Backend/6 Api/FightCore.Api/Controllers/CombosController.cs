using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FightCore.Api.Resources.Characters;
using FightCore.Repositories.Patterns;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;

        public CombosController(IUnitOfWorkAsync unitOfWorkAsync, IMapper mapper)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all of the combo objects known to FightCore
        /// </summary>
        /// <returns>
        /// 200: Array of simple combo objects
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCombosAsync()
        {
            return Ok();
        }

        /// <summary>
        /// Gets all the combos for the gameId provided
        /// </summary>
        /// <param name="gameId">The id of the game wanted to have all combos from</param>
        /// <returns>
        /// 200: Array of simple combo objects
        /// 404: No combos have been found for that game
        /// 400: Incorrect gameId was supplied
        /// </returns>
        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetCombosByGameAsync(int gameId)
        {
            return Ok();
        }

        /// <summary>
        /// Gets all the combos for the characterId provided
        /// </summary>
        /// <param name="characterId">The id of the character wanted to have all combos from</param>
        /// <returns>
        /// 200: Array of simple combo objects
        /// 404: No combos have been found for that game
        /// 400: Incorrect gameId was supplied
        /// </returns>
        [HttpGet("character/{characterId}")]
        public async Task<IActionResult> GetCombosByCharacterAsync(int characterId)
        {
            return Ok();
        }

        /// <summary>
        /// Gets the full combo object based on the id provided
        /// </summary>
        /// <param name="id">The id of the combo object wanting to be seen</param>
        /// <returns>
        /// 200: A detailed combo object
        /// 404: Combo with that id does not exist
        /// 400: Id is lower than 1
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComboByIdAsync(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Searches for combos based on the name provided.
        /// The combo name may just contain the given name.
        /// </summary>
        /// <param name="name">The name of the combo wanting to be looked for.</param>
        /// <returns>
        /// 200: An array of combo objects
        /// 404: No combos were found with that name
        /// 400: name string was null or whitespace
        /// </returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetComboByNameAsync(string name)
        {
            return Ok();
        }

        /// <summary>
        /// Creates a new combo based on the given parameter.
        /// User needs to be logged in to do so.
        /// </summary>
        /// <param name="detailedCombo">The combo article wanting to be published</param>
        /// <returns>
        /// 203: Combo has been created and is at this location.
        /// 400: Combo object is wrong.
        /// </returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetailedComboResource detailedCombo)
        {
            return Ok();
        }
    }
}