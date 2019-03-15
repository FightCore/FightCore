using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers.V1
{
    /// <inheritdoc />
    [Route("[controller]")]
	[ApiController]
	[ApiVersion("1")]
	public class GDPRController : ControllerBase
    {
		/// <summary>
		/// Gets all information known about the user.
		/// </summary>
		/// <returns></returns>
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetInfo()
		{
		    await Task.Delay(0);
			return Ok();
		}

		/// <summary>
		/// Request to remove the user's data.
		/// </summary>
		/// <returns></returns>
		[Authorize]
		[HttpDelete]
		public async Task<IActionResult> DeleteUser()
		{
		    await Task.Delay(0);
			return Ok();
		}
    }
}