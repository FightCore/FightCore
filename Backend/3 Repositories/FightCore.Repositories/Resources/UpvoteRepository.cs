﻿using System;
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
        /// <param name="userId">The id of the user.</param>
        /// <returns>The amount of upvotes.</returns>
        Task<Upvote> GetUpvotesByPost(int postId, int userId);
    }

    public class UpvoteRepository : Repository<Upvote>, IUpvoteRepository
    {
        public UpvoteRepository(DbContext context)
            : base(context)
        {
        }

        public Task<Upvote> GetUpvotesByPost(int postId, int userId)
        {
            return Queryable.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);
        }
    }
}