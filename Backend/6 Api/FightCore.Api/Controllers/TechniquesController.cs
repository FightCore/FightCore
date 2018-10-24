using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Models.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services.Characters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TechniquesController : ControllerBase
    {
        private readonly ITechniqueService _techniqueService;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;

        /// <summary>
        /// Testing comments
        /// </summary>
        /// <param name="techniqueService"></param>
        /// <param name="mapper"></param>
        public TechniquesController(ITechniqueService techniqueService, IMapper mapper, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _techniqueService = techniqueService;
            _mapper = mapper;
            _unitOfWorkAsync = unitOfWorkAsync;
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
            {
                return NotFound();
            }

            var resources = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(resources);
        }

        /// <summary>
        /// Get a specific Technique by id
        /// </summary>
        /// <param name="id">The Id of the technique object you want.</param>
        /// <returns>
        /// 200: A single technique object
        /// 404: Object has not been found
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechniqueByIdAsync(int id)
        {
            var technique = await _techniqueService.FindByIdAsync(id);

            if (technique == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<DetailedTechniqueResource>(technique);

            return Ok(resource);
        }

        /// <summary>
        /// Get all technique objects for a game.
        /// </summary>
        /// <param name="gameId">The id of the game you want the techniques from.</param>
        /// <returns>
        /// 200: An array of technique objects.
        /// 404: Object has not been found.
        /// </returns>
        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetTechniquesByGameAsync(int gameId)
        {
            var techniques = await _techniqueService.GetTechniquesByGameAsync(gameId);

            if (!techniques.Any())
                return NotFound();

            var resources = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(resources);
        }

        /// <summary>
        /// Search for a technique by name
        /// </summary>
        /// <param name="name">The name of the technique wanting to be searched for</param>
        /// <returns>
        /// 400: The name was incorrect
        /// 404: No technique with that name was found
        /// 200: An array of technique objects that contain that name
        /// </returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTechniqueByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }

            var techniques = await _techniqueService.GetTechniqueContainingNameAsync(name);

            if (!techniques.Any())
            {
                return NotFound(name);
            }

            var mappedTechniques = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(mappedTechniques);
        }

        /// <summary>
        /// Creates a technique object based on the current authorized user and the technique object provided
        /// </summary>
        /// <param name="technique">The technique post wanting to be saved</param>
        /// <returns>
        /// 403: User is not authorized
        /// 203: Redirect to the created resource
        /// 400: Something is wrong with the technique object
        /// </returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TechniqueResource technique)
        {
            var techniqueObject = _mapper.Map<Technique>(technique);

            if (techniqueObject == null)
            {
                return BadRequest();
            }

            techniqueObject = await _techniqueService.InsertAsync(techniqueObject);
            await _unitOfWorkAsync.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTechniqueByIdAsync), new { id = techniqueObject.Id }, _mapper.Map<TechniqueResource>(techniqueObject));
        }
    }
}