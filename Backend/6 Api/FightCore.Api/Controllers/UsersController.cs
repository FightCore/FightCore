using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Models;
using FightCore.Repositories.Patterns;
using FightCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userService"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        public UsersController(IUnitOfWorkAsync unitOfWork, IUserService userService, UserManager<ApplicationUser> userManager, IMapper mapper,
            ILogger<UsersController> logger)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets the user for the given id
        /// </summary>
        /// <param name="id">The id that the user is associated with</param>
        /// <returns>User information of the given id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Getting user with id {0}", id);
            var profiler = MiniProfiler.Current;
            ApplicationUser user;
            using (profiler.Step("Getting user from database"))
            {
                 user = await _userService.FindByIdAsync(id);
            }

            if (user == null)
                return NotFound();
            using (profiler.Step("Mapping and returning"))
            {
                return Ok(_mapper.Map<UserResultResource>(user));
            }
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            if (users == null || !users.Any())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<UserResultResource>>(users));
        }

        /// <summary>
        /// Adds a user from a given resource
        /// </summary>
        /// <param name="userResource">The resource with the data of the new user</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewUserResource userResource)
        {
            var user = _mapper.Map<ApplicationUser>(userResource);
            await _userManager.CreateAsync(user, userResource.Password);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { Id = user.Id }, _mapper.Map<UserResultResource>(user));
        }
    }
}