﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FightCore.Models.Resources;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Resources
{
    public interface IPostRepository : IRepositoryAsync<Post>
    {
        Task<int> GetPostCountAsync(ResourceCategory? category);

        IEnumerable<Post> GetPosts(int pageSize, int pageNumber, SortCategory sortOption, ResourceCategory? category);
    }
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }
        
        public async Task<int> GetPostCountAsync(ResourceCategory? category)
        {
            if(category != null)
            {
                return await Queryable.CountAsync(x => x.Category == category);
            }
            else
            {
                return await Queryable.CountAsync();
            }
        }

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
                return sorted
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize);
            }
            else
            {
                return sorted
                    .Where(x => x.Category == category)
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize);
            }

            
        }

    }
}
