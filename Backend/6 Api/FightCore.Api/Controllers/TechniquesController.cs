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
    [Route("api/[controller]")]
    [ApiController]
    public class TechniquesController : ControllerBase
    {
        private readonly ITechniqueService _techniqueService;
        private readonly IMapper _mapper;

        public TechniquesController(ITechniqueService techniqueService, IMapper mapper)
        {
            _techniqueService = techniqueService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTechniquesAsync()
        {
            var techniques = await _techniqueService.GetTechniquesAsync();

            if (!techniques.Any())
                return BadRequest();

            var resources = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(resources);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetTechniqueByIdAsync(int id)
        {
            var technique = await _techniqueService.GetTechniqueByIdAsync(id);

            if (technique == null)
                return BadRequest();

            var resource = _mapper.Map<TechniqueResource>(technique);

            return Ok(resource);
        }

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetTechniquesByGameAsync(int gameId)
        {
            var techniques = await _techniqueService.GetTechniquesByGameAsync(gameId);

            if (!techniques.Any())
                return BadRequest();

            var resources = _mapper.Map<List<TechniqueResource>>(techniques);

            return Ok(resources);
        }
    }
}