using AutoMapper;
using FightCore.Api.Resources.Posts;
using FightCore.Models;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using FightCore.Resources.Controllers;
using FightCore.Resources.Controllers.Shared;
using FightCore.Services.Resources;
using Ganss.XSS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Controllers.V1
{
    /// <summary>
    /// The controller for the <see cref="Post"/> class
    /// </summary>
    /// <inheritdoc/>
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class LibraryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPostService _postService;
        private readonly IUpvoteService _upvoteService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <inheritdoc/>
        public LibraryController(
            IConfiguration configuration,
            IUnitOfWorkAsync unitOfWork,
            IPostService userResourceService,
            IUpvoteService upvoteService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _postService = userResourceService;
            _upvoteService = upvoteService;
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
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResultResource))]
        public async Task<IActionResult> GetPostsAsync(int pageSize = 25, int pageNumber = 1, int sortOption = 1, int categoryFilter = -1)
        {
            // Basic validation checking
            if (pageNumber < 1)
            {
                return BadRequest(LibraryResources.PageNumberInvalid);
            }

            // Page size must be valid (greater than 0, max is in configuration)
            int.TryParse(_configuration["PostMaxPageSize"], out var maxPageSize);
            if (pageSize < 1 || pageSize > maxPageSize)
            {
                return BadRequest(string.Format(LibraryResources.PageSizeWrongSize, maxPageSize));
            }

            // Sort option must be valid part of enum (IsDefined isn't safe so checking first to last value)
            if (!Enum.IsDefined(typeof(SortCategory), sortOption))
            {
                return BadRequest(LibraryResources.SortOptionInvalid);
            }

            // Explicitly set and check category filter
            ResourceCategory? category;
            if (categoryFilter == -1)
            {
                category = null;
            }
            else if (!Enum.IsDefined(typeof(ResourceCategory), categoryFilter))
            {
                return BadRequest(LibraryResources.CategoryFilterInvalid);
            }
            else
            {
                category = (ResourceCategory)categoryFilter;
            }

            // Get total count of results
            var totalPosts = await _postService.GetPostCountAsync(category);

            // If no results, can wrap things up here
            if (totalPosts < 1)
            {
                var pagedResult = new PostsResultResource(
                    pageSize,
                    pageNumber,
                    totalPosts,
                    new List<PostPreviewResource>());

                return Ok(pagedResult);
            }

            // If pageNumber is outside range, bad request. No point in trying to grab posts
            if ((pageNumber - 1) * pageSize > totalPosts)
            {
                return BadRequest(LibraryResources.PageNumberOutsideRange);
            }

            // Otherwise, finally get the sorted and optionally filtered page of posts
            var posts = _postService.GetPosts(pageSize, pageNumber, (SortCategory)sortOption, category);
            var result = new PostsResultResource(
                pageSize,
                pageNumber,
                totalPosts,
                _mapper.Map<List<PostPreviewResource>>(posts));

            return Ok(result);
        }

        /// <summary>
        /// Gets the post based on the provided user.
        /// </summary>
        /// <param name="userId">The user's id.</param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResultResource))]
        public async Task<IActionResult> GetPostsByUserAsync(int userId)
        {
            var isMyUser = !(int.TryParse(_userManager.GetUserId(User), out var myUserId) == false && myUserId == userId);

            var posts = await _postService.GetPostsByUser(userId, isMyUser);

            if (!posts.Any())
            {
                return NotFound();
            }

            var mappedPosts = _mapper.Map<List<PostPreviewResource>>(posts);

            return Ok(mappedPosts);
        }

        /// <summary>
        /// Gets the post by an id.
        /// </summary>
        /// <param name="id">The id of the post.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResultResource))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByIdAsync(int id)
        {
            var resource = await _postService.FindByIdAsync(id);

            if (resource == null)
            {
                return NotFound(string.Format(ApiResources.NotFound, nameof(Post), id));
            }

            var resourceMapped = _mapper.Map<PostResultResource>(resource);

            return Ok(resourceMapped);
        }

        /// <summary>
        /// Creates a resource based on the provided data
        /// </summary>
        /// <param name="postInput">Post to create</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] PostResource postInput)
        {
            // Clean up title, content, and link as necessary (currently just basic HTMl sanitization to prevent XSS)
            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowedAttributes.Add("class");
            postInput.Title = sanitizer.Sanitize(postInput.Title);
            postInput.Content = sanitizer.Sanitize(postInput.Content);
            postInput.FeaturedLink = sanitizer.Sanitize(postInput.FeaturedLink);

            // Verify inputs are still valid
            if (string.IsNullOrWhiteSpace(postInput.Title))
            {
                return BadRequest(LibraryResources.TitleCannotBeBlank);
            }

            if (string.IsNullOrWhiteSpace(postInput.Content) && string.IsNullOrWhiteSpace(postInput.FeaturedLink))
            {
                return BadRequest(LibraryResources.TitleAndLinkBlank);
            }

            // Create the post and initialize basic necessary properties
            var post = _mapper.Map<Post>(postInput);

            if (int.TryParse(_userManager.GetUserId(User), out var userId) == false)
            {
                return Unauthorized();
            }

            post.AuthorId = userId;
            post.CreatedDate = DateTime.Now;

            // Add post to database
            await _postService.InsertAsync(post);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostByIdAsync), new { Id = post.Id }, _mapper.Map<PostResultResource>(post));
        }

        /// <summary>
        /// Updates the given post.
        /// </summary>
        /// <param name="post">The post wanting to be updated.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] PostResultResource post)
        {
            var oldPost = await _postService.FindByIdAsync(post.Id);
            if (oldPost == null)
            {
                return NotFound();
            }

            int.TryParse(_userManager.GetUserId(User), out var userId);
            if (oldPost.AuthorId != userId)
            {
                return Unauthorized();
            }

            var postEntity = _mapper.Map<Post>(post);
            _postService.Update(postEntity);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Deletes the post with the given id.
        /// </summary>
        /// <param name="id">The id of the post wanting to be deleted.</param>
        /// <response code="200">Post has successfully been deleted.</response>
        /// <response code="401">The post you are deleting isn't yours.</response>
        /// <response code="404">The post you are wanting to delete isn't found.</response>
        /// <returns>An awaitable task.</returns>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.FindByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            int.TryParse(_userManager.GetUserId(User), out var userId);
            if (post.AuthorId != userId)
            {
                return Unauthorized();
            }

            await _postService.DeleteByIdAsync(id);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Publishes or hides a post by the given id and state.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("publish/{id}/{isPublic}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Publish(int id, bool isPublic = true)
        {
            var post = await _postService.FindByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            int.TryParse(_userManager.GetUserId(User), out var userId);
            if (post.AuthorId != userId)
            {
                return Unauthorized();
            }

            post.Published = isPublic;
            _postService.Update(post);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPost("upvote")]
        public async Task<IActionResult> Upvote([FromBody] int postId)
        {
            int.TryParse(_userManager.GetUserId(User), out var userId);

            var upvote = await _upvoteService.GetUpvotesByPost(postId, userId);

            if (upvote != null)
            {
                _upvoteService.Delete(upvote);
                await _unitOfWork.SaveChangesAsync();

                return Ok(false);
            }

            upvote = new Upvote() { PostId = postId, UserId = userId };

            await _upvoteService.InsertAsync(upvote);
            await _unitOfWork.SaveChangesAsync();

            return Ok(true);
        }

    }
}