using System;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Repositories.Patterns;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers{
    [Route("set")]
    [ApiController]
    public class SetController : Controller { 
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;

        public SetController (IUnitOfWorkAsync unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public Task<IActionResult> GetSetByIdAsync (int id) {
            throw new NotImplementedException();
        }

        [HttpGet("player/{playerId}")]
        public Task<IActionResult> GetSetsByPlayerAsync (int playerId) {
            throw new NotImplementedException();
        }
        
        [HttpGet("event/{eventId}")]
        public Task<IActionResult> GetSetsByEventAsync (int eventId) {
            throw new NotImplementedException();
        }

        [HttpGet("tournament/{tournamentId}")]
        public Task<IActionResult> GetSetsByTournamentAsync (int tournamentId) {
            throw new NotImplementedException();
        }
    }
}