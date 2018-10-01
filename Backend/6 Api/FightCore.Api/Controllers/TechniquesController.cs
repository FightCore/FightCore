using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Services.Characters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TechniquesController : ControllerBase
    {
        private readonly ITechniqueService _techniqueService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Testing comments
        /// </summary>
        /// <param name="techniqueService"></param>
        /// <param name="mapper"></param>
        public TechniquesController(ITechniqueService techniqueService, IMapper mapper)
        {
            _techniqueService = techniqueService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all techniques known to FightCore
        /// </summary>
        /// <returns>An array of technique objects</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTechniquesAsync()
        {
            var techniques = await _techniqueService.GetTechniquesAsync();

            if (!techniques.Any())
                return NotFound();

            var resources = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(resources);
        }

        /// <summary>
        /// Get a specific Technique by id
        /// </summary>
        /// <param name="id">The Id of the technique object you want.</param>
        /// <returns>A single technique object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechniqueByIdAsync(int id)
        {
            var technique = await _techniqueService.FindByIdAsync(id);

            if (technique == null)
                return NotFound();

            var resource = _mapper.Map<TechniqueResource>(technique);

            return Ok(resource);
        }

        /// <summary>
        /// Get all technique objects for a game.
        /// </summary>
        /// <param name="gameid">The id of the game you want the techniques from.</param>
        /// <returns>An array of technique objects.</returns>
        [HttpGet("game/{gameid}")]
        public async Task<IActionResult> GetTechniquesByGameAsync(int gameid)
        {
            var techniques = await _techniqueService.GetTechniquesByGameAsync(gameid);

            if (!techniques.Any())
                return NotFound();

            var resources = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(resources);
        }
    }
}