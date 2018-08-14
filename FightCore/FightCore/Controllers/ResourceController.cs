using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Controllers
{
    public class ResourceController : BaseController
    {
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetResourceList()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetResourceById(int id, int type)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetResourcesByGame(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}