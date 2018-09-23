using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Repositories.Patterns;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : Controller { 
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerController (IUnitOfWorkAsync unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetPlayerByIdAsync(int id) {
            throw new NotImplementedException();
        }

        [HttpGet("stats/{id}")]
        public Task<IActionResult> GetPlayerStatsByPlayerIdAsync(int id){
            throw new NotImplementedException();
        }
    }
}