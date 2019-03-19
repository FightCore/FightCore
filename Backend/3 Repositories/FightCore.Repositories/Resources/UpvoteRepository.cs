using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;

using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Resources
{
    public interface IUpvoteRepository : IRepositoryAsync<Upvote>
    {
        /// <summary>
        /// Gets the amount of upvotes by a post.
        /// </summary>
        /// <param name="postId">The id of the post.</param>
        /// <returns>The amount of upvotes.</returns>
        Task<int> GetUpvotesByPost(int postId);
    }

    public class UpvoteRepository : Repository<Upvote>, IUpvoteRepository
    {
        public UpvoteRepository(DbContext context)
            : base(context)
        {
        }

        public Task<int> GetUpvotesByPost(int postId)
        {
            return Queryable.CountAsync(x => x.PostId == postId);
        }
    }
}
