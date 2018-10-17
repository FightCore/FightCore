using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Models;
using FightCore.Repositories.Patterns;
using FightCore.Services.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    /// <summary>
    /// The controller for the <see cref="FightCore.Models.Resources.UserResource"/> class
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IUserResourceService _userResourceService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public LibraryController(IUnitOfWorkAsync unitOfWork, IUserResourceService userResourceService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userResourceService = userResourceService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserResourcesAsync()
        {
            var resources = await _userResourceService.GetAllAsync();

            var resourcesMapped = _mapper.Map<List<UserPostResource>>(resources);

            return Ok(resourcesMapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserResourceByIdAsync(int id)
        {
            var resource = await _userResourceService.FindByIdAsync(id);

            if (resource == null)
                return NotFound();

            var resourceMapped = _mapper.Map<UserPostResource>(resource);

            return Ok(resourceMapped);
        }

        /// <summary>
        /// Creates a resource based on the provided data
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserPostResource userPost)
        {
            var resource = _mapper.Map<Models.Resources.UserResource>(userPost);

            var userId = _userManager.GetUserId(User);

            //Our user ids are ints so can safely convert this over
            if (resource.AuthorId != Convert.ToInt32(userId))
                return BadRequest();

            await _userResourceService.InsertAsync(resource);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserResourceByIdAsync), new { Id = resource.Id }, _mapper.Map<UserPostResource>(resource));
        }
    }
}