using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.Resources;
using FightCore.Services.Patterns;

namespace FightCore.Services.Resources
{
    public interface IPostService : IEntityService<Post>
    {
        /// <summary>
        /// Gets the total posts matching given optional filters
        /// </summary>
        /// <param name="category">Optionally filter on this post category</param>
        /// <returns>Total posts count</returns>
        Task<int> GetPostCountAsync(ResourceCategory? category);

        /// <summary>
        /// Gets a page of posts
        /// </summary>
        /// <param name="pageSize">Size per page of posts</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="sortOption">How results should be ordered</param>
        /// <param name="category">Optionally filter on this post category</param>
        /// <returns>Posts for given page</returns>
        IEnumerable<Post> GetPosts(int pageSize, int pageNumber, SortCategory sortOption, ResourceCategory? category);

        /// <summary>
        /// Gets the posts made by the user.
        /// If the user is the current user it will also get unpublished posts.
        /// </summary>
        /// <param name="userId">The user's id.</param>
        /// <param name="isCurrentUser">If the user is the current user.</param>
        /// <returns>A collection of posts.</returns>
        Task<List<Post>> GetPostsByUser(int userId, bool isCurrentUser);
    }

    public class PostService : EntityService<Post>, IPostService
    {
        private readonly IPostRepository _repository;

        /// <inheritdoc />
        public PostService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <inheritdoc cref="IPostService.GetPostCountAsync"/>
        public Task<int> GetPostCountAsync(ResourceCategory? category)
        {
            return _repository.GetPostCountAsync(category);
        }

        /// <inheritdoc/>
        public override Task<Post> FindByIdAsync(int id)
        {
            return _repository.GetPostById(id);
        }

        /// <inheritdoc cref="IPostService.GetPosts"/>
        public IEnumerable<Post> GetPosts(int pageSize, int pageNumber, SortCategory sortOption, ResourceCategory? category)
        {
            return _repository.GetPosts(pageSize, pageNumber, sortOption, category);
        }

        public Task<List<Post>> GetPostsByUser(int userId, bool isCurrentUser)
        {
            return _repository.GetPostsByUser(userId, isCurrentUser);
        }
    }
}
