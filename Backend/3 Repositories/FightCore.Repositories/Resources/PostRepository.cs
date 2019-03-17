using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Repositories.Resources
{
    public interface IPostRepository : IRepositoryAsync<Post>
    {
        /// <summary>
        /// Gets the amount of posts of the given category,
        /// </summary>
        /// <param name="category">the category wanting to be searched for.</param>
        /// <returns>An awaitable task with the result being the amount of posts in that category.</returns>
        Task<int> GetPostCountAsync(ResourceCategory? category);

        /// <summary>
        /// Gets the posts based on the given parameters.
        /// </summary>
        /// <param name="pageSize">The amount of items per page.</param>
        /// <param name="pageNumber">The page number wanting to be gotten (1 based).</param>
        /// <param name="sortOption">How the posts should be sorted.</param>
        /// <param name="category">Which category should be used.</param>
        /// <returns>A collection of <see cref="Post"/> object.s</returns>
        IEnumerable<Post> GetPosts(int pageSize, int pageNumber, SortCategory sortOption, ResourceCategory? category);

        /// <summary>
        /// Gets a post objected based on the Id.
        /// </summary>
        /// <param name="id">The id wanting to be searched for.</param>
        /// <returns>The post or NULL.</returns>
        Task<Post> GetPostById(int id);

        /// <summary>
        /// Gets the post from the specified user.
        /// </summary>
        /// <param name="userId">The user's id.</param>
        /// <param name="isCurrentUser">If the user is the current user.</param>
        /// <returns>A list of posts.</returns>
        Task<List<Post>> GetPostsByUser(int userId, bool isCurrentUser);
    }

    public class PostRepository : Repository<Post>, IPostRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class.
        /// </summary>
        /// <param name="context">The context wanting to be inserted.</param>
        /// <inheritdoc/>
        public PostRepository(DbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public Task<int> GetPostCountAsync(ResourceCategory? category)
        {
            return category != null ? Queryable.CountAsync(x => x.Category == category) : Queryable.CountAsync();
        }

        /// <inheritdoc />
        public IEnumerable<Post> GetPosts(int pageSize, int pageNumber, SortCategory sortOption, ResourceCategory? category)
        {
            IOrderedQueryable<Post> sorted;
            switch (sortOption)
            {
                case SortCategory.Popular:
                    sorted = Queryable.OrderByDescending(x => x.Views);
                    break;
                case SortCategory.Latest:
                    sorted = Queryable.OrderByDescending(x => x.CreatedDate);
                    break;
                default: // No rating implementation just yet
                    sorted = Queryable.OrderByDescending(x => x.Id);
                    break;
            }


            if (category == null)
            {
                return sorted.Include(p => p.Author).Where(x => x.Published).Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }

            return sorted.Include(p => p.Author).Where(x => x.Category == category && x.Published).Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }

        public Task<List<Post>> GetPostsByUser(int userId, bool isCurrentUser)
        {
            var queryable = Queryable.Where(x => x.AuthorId == userId);

            if (!isCurrentUser)
            {
                queryable.Where(x => x.Published);
            }

            return queryable.ToListAsync();
        }

        /// <inheritdoc/>
        public Task<Post> GetPostById(int id)
        {
            return Queryable.Include(p => p.Author).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
