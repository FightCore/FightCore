using System;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Repositories.Patterns;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers{
    [Route("h2h")]
    [ApiController]
    public class Head2HeadController : Controller {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="Head2HeadControler"/> class
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public Head2HeadController (IUnitOfWorkAsync unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the head to head statistics for two users against each other
        /// </summary>
        /// <param name="player1">The id of the first player</param>
        /// <param name="player2">The id of the second player</param>
        /// <returns>TODO add the right resource</returns>
        public Task<IActionResult> GetH2HStatistics(int player1, int player2){
            throw new NotImplementedException();
        }
    }
}