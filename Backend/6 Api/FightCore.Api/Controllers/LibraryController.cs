using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FightCore.Api.Posts.Resources;
using FightCore.Api.Resources.Posts;
using FightCore.Models;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using FightCore.Services.Resources;
using Ganss.XSS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FightCore.Api.Controllers
{
    /// <summary>
    /// The controller for the <see cref="FightCore.Models.Resources.Post"/> class
    /// </summary>
    [Route("[controller]")]
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

        /// <summary>
        /// Gets a single page of posts
        /// </summary>
        /// <param name="pageSize">Size of posts page to return. Must be greater than 0</param>
        /// <param name="pageNumber">Page index to retrieve, 1 is first page</param>
        /// <param name="sortOption">Sort option represented by <see cref="Models.Resources.SortCategory"/></param>
        /// <param name="categoryFilter">Optionally filter by post category. Set to -1 for not using this filter or set to appropriate value from <see cref="Models.Resources.ResourceCategory"/></param>
        /// <returns>
        /// 200 with a page of posts
        /// 400 if any inputs are invalid
        /// </returns>
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

        /// <summary>
        /// Gets a single post's full info via id
        /// </summary>
        /// <param name="id">Post's id to retrieve</param>
        /// <returns>200 with post's full info</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByIdAsync(int id)
        {
            var resource = await _postService.FindByIdAsync(id);

            if (resource == null)
                return NotFound();

            var resourceMapped = _mapper.Map<PostResultResource>(resource);

            return Ok(resourceMapped);
        }

        /// <summary>
        /// Creates a post based on the provided data
        /// </summary>
        /// <param name="postInput">Post to create</param>
        /// <returns>
        /// 200 with full post's info
        /// 400 if inputs aren't valid
        /// </returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostResource postInput)
        {
            // Clean up title, content, and link as necessary (currently just basic HTMl sanitization to prevent XSS)
            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowedAttributes.Add("class");
            postInput.Title = sanitizer.Sanitize(postInput.Title);
            postInput.Content = sanitizer.Sanitize(postInput.Content);
            postInput.FeaturedLink = sanitizer.Sanitize(postInput.FeaturedLink);

            // Verify inputs are still valid
            // TODO: Varify category appropriately separately
            if(String.IsNullOrWhiteSpace(postInput.Title))
            {
                return BadRequest("Title cannot be blank");
            }
            if(String.IsNullOrWhiteSpace(postInput.Content) && String.IsNullOrWhiteSpace(postInput.FeaturedLink))
            {
                return BadRequest("Both Content and FeaturedLink cannot be blank");
            }

            // Create the post and initialize basic necessary properties
            var post = _mapper.Map<Models.Resources.Post>(postInput);
            int userId;
            Int32.TryParse(_userManager.GetUserId(User), out userId);
            post.AuthorId = userId;
            post.CreatedDate = DateTime.Now;

            // Add post to database
            await _postService.InsertAsync(post);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostByIdAsync), new { Id = post.Id }, _mapper.Map<PostResultResource>(post));
        }
    }
}