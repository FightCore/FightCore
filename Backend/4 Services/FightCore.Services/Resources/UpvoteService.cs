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
    public interface IUpvoteService : IService<Upvote>
    {
        /// <summary>
        /// Gets the amount of upvotes by a post.
        /// </summary>
        /// <param name="postId">The id of the post.</param>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The amount of upvotes.</returns>
        Task<Upvote> GetUpvotesByPost(int postId, int userId);
    }

    public class UpvoteService : Service<Upvote>, IUpvoteService
    {
        private readonly IUpvoteRepository _repository;

        /// <inheritdoc />
        public UpvoteService(IUpvoteRepository repository)
            : base(repository)
        {
            this._repository = repository;
        }

        /// <inheritdoc />
        public Task<Upvote> GetUpvotesByPost(int postId, int userId)
        {
            return _repository.GetUpvotesByPost(postId, userId);
        }
    }
}
