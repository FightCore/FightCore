using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Resources;
using FightCore.Models;
using FightCore.Repositories.Patterns;
using FightCore.Services;
using FightCore.Services.Characters;
using FightCore.Services.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FightCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IUserService _userService;
        private readonly ICharacterService _characterService;
        private readonly IGameService _gameService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userService"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        public UsersController(IUnitOfWorkAsync unitOfWork, IUserService userService, IGameService gameService, ICharacterService characterService,
                               UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _characterService = characterService;
            _gameService = gameService;
        }

        /// <summary>
        /// Gets the user for the given id
        /// </summary>
        /// <param name="id">The id that the user is associated with</param>
        /// <returns>User information of the given id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserResource>(user));
        }

        /// <summary>
        /// Gets the details about the user currently authorized
        /// </summary>
        /// <returns>
        /// 200 with the details of the current user
        /// 403 if the user is not authorized
        /// </returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserDetails()
        {
            var currentId = _userManager.GetUserId(ClaimsPrincipal.Current);
            var user = await _userService.FindByIdAsync(Convert.ToInt32(currentId));

            return Ok(_mapper.Map<UserResultResource>(user));
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            if (users == null || !users.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UserResource>>(users));
        }

        /// <summary>
        /// Updates the user to the given changes.
        /// </summary>
        /// <returns></returns>
        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UserMetaDataResource metaData)
        {
            var currentId = _userManager.GetUserId(ClaimsPrincipal.Current);
            var user = await _userService.FindByIdAsync(Convert.ToInt32(currentId));

            var characters = await _characterService.GetAllCharactersByIdsAsync(metaData.FavoriteCharacters);
            var games = await _gameService.GetAllGamesByIdsAsync(metaData.FavoriteGames);

            _userService.UpdateUserForMetaData(user, games, characters, metaData.Bio);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Adds a user from a given resource
        /// </summary>
        /// <param name="userResource">The resource with the data of the new user</param>
        /// <returns>
        /// Will return a 201 with the Id of the user when the user has been created.
        /// Will return a 409 if there are issues with the register.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewUserResource userResource)
        {
            var user = _mapper.Map<ApplicationUser>(userResource);
            var result = await _userManager.CreateAsync(user, userResource.Password);

            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(this.Get), new { user.Id }, _mapper.Map<UserResource>(user));
            }

            return Conflict(result.Errors);
        }
    }
}