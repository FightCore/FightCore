using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Posts.Resources;
using FightCore.Api.Resources;
using FightCore.Api.Resources.Posts;
using FightCore.Models;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using FightCore.Services.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FightCore.Api.Controllers
{
    /// <summary>
    /// The controller for the <see cref="FightCore.Models.Resources.Post"/> class
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public LibraryController(IConfiguration configuration, IUnitOfWorkAsync unitOfWork, IPostService userResourceService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _postService = userResourceService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            var resources = await _postService.GetAllAsync();

            var resourcesMapped = _mapper.Map<List<PostResource>>(resources);

            return Ok(resourcesMapped);
        }

        /// <summary>
        /// Gets a single page of posts
        /// </summary>
        /// <param name="pageSize">Size of posts page to return. Must be greater than 0</param>
        /// <param name="pageNumber">Page index to retrieve, 1 is first page</param>
        /// <param name="sortOption">Sort option represented by <see cref="Models.Resources.SortCategory"/></param>
        /// <param name="categoryFilter">Optionally filter by post category. Set to -1 for not using this filter or set to appropriate value from <see cref="Models.Resources.ResourceCategory"/></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPostsAsync(int pageSize, int pageNumber, int sortOption, int categoryFilter)
        {
            PostsResultResource result;

            // Basic validation checking
            if (pageNumber < 1)
            {
                return BadRequest("Page number must be valid");
            }
            // Page size must be valid (greater than 0, max is in configuration)
            int maxPageSize;
            Int32.TryParse(_configuration["PostMaxPageSize"], out maxPageSize);
            if(pageSize < 1 || pageSize > maxPageSize)
            {
                return BadRequest("Page size must be greater than 0 but no greater than " + maxPageSize);
            }
            //  Sort option must be valid part of enum (IsDefined isn't safe so checking first to last value)
            if(!Enum.IsDefined(typeof(SortCategory), sortOption))
            {
                return BadRequest("Sort option must be valid");
            }
            // Explicitly set and check category filter
            ResourceCategory? category;
            if(categoryFilter == -1)
            {
                category = null;
            }
            else if(!Enum.IsDefined(typeof(ResourceCategory), categoryFilter))
            {
                return BadRequest("Category filter must be -1 or must be a valid category value");
            }
            else
            {
                category = (ResourceCategory)categoryFilter;
            }

            // Get total count of results
            int totalPosts = await _postService.GetPostCountAsync(category);
            // If no results, can wrap things up here
            if(totalPosts < 1)
            {
                result = new PostsResultResource
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                    Total = totalPosts,
                    Posts = new List<PostPreviewResource>()
                };

                return Ok(result);
            }

            // If pageNumber is outside range, bad request. No point in trying to grab posts
            if((pageNumber - 1) * pageSize > totalPosts)
            {
                return BadRequest("Page number is outside range");
            }

            // Otherwise, finally get the sorted and optionally filtered page of posts
            var posts = _postService.GetPosts(pageSize, pageNumber, (SortCategory)sortOption, category);
            result = new PostsResultResource
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                Total = totalPosts,
                Posts = _mapper.Map<List<PostPreviewResource>>(posts)
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostsByIdAsync(int id)
        {
            var resource = await _postService.FindByIdAsync(id);

            if (resource == null)
                return NotFound();

            var resourceMapped = _mapper.Map<PostResource>(resource);

            return Ok(resourceMapped);
        }

        /// <summary>
        /// Creates a resource based on the provided data
        /// </summary>
        /// <param name="userPost"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostResource userPost)
        {
            var resource = _mapper.Map<Models.Resources.Post>(userPost);

            var userId = _userManager.GetUserId(User);

            //Our user ids are ints so can safely convert this over
            if (resource.AuthorId != Convert.ToInt32(userId))
                return BadRequest();

            resource.CreatedDate = DateTime.Now;
            await _postService.InsertAsync(resource);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostsByIdAsync), new { Id = resource.Id }, _mapper.Map<PostResource>(resource));
        }
    }
}