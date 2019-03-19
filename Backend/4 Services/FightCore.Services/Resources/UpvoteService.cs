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
        /// <returns>The amount of upvotes.</returns>
        Task<int> GetUpvotesByPost(int postId);
    }

    public class UpvoteService : Service<Upvote>, IUpvoteService
    {
        private readonly IUpvoteRepository _repository;

        /// <inheritdoc />
        public UpvoteService(UpvoteRepository repository)
            : base(repository)
        {
            this._repository = repository;
        }

        /// <inheritdoc />
        public Task<int> GetUpvotesByPost(int postId)
        {
            return _repository.GetUpvotesByPost(postId);
        }
    }
}
