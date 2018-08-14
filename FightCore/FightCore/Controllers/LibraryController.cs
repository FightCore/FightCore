using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Controllers
{
    public class LibraryController : BaseController
    {
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult CreatePost()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> CreatePost(object model)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> ViewPost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetPostsBySearch(string searchTerms)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> FavoritePost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}