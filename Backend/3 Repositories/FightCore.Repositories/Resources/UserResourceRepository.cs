using System;
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
    public interface IUserResourceRepository : IRepositoryAsync<UserResource>
    {
        Task<int> GetPostCountAsync();

        IEnumerable<UserResource> GetPosts(int pageSize, int pageNumber, SortCategory sortOption);
    }
    public class UserResourceRepository : Repository<UserResource>, IUserResourceRepository
    {
        public UserResourceRepository(DbContext context) : base(context)
        {
        }
        
        public async Task<int> GetPostCountAsync()
        {
            return await Queryable.CountAsync();
        }

        public IEnumerable<UserResource> GetPosts(int pageSize, int pageNumber, SortCategory sortOption)
        {
            IOrderedQueryable<UserResource> sorted;
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

            return sorted
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

    }
}
