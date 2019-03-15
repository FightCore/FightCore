using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers.V1
{
    /// <inheritdoc />
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class DashboardController : ControllerBase
    {
        /// <summary>
        /// Gets the featured posts for a game, if <paramref name="gameId"/> is not provided.
        /// Grabs the general featured posts.
        /// </summary>
        /// <param name="gameId">The id of the game</param>
        /// <returns></returns>
        [HttpGet("featured/{gameId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFeatured(int gameId = 0)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}