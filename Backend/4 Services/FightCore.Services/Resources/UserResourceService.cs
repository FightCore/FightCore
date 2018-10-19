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
    public interface IUserResourceService : IEntityService<UserResource>
    {
        /// <summary>
        /// Gets the total posts matching given optional filters (to be done)
        /// </summary>
        /// <returns>Total posts count</returns>
        Task<int> GetPostCountAsync();

        /// <summary>
        /// Gets a page of posts
        /// </summary>
        /// <param name="pageSize">Size per page of posts</param>
        /// <param name="pageNumber">Page index</param>
        /// <param name="sortOption">How results should be ordered</param>
        /// <returns>Posts for given page</returns>
        IEnumerable<UserResource> GetPosts(int pageSize, int pageNumber, SortCategory sortOption);
    }
    public class UserResourceService : EntityService<UserResource>, IUserResourceService
    {
        private readonly IUserResourceRepository _repository;

        public UserResourceService(IUserResourceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <inheritdoc cref="IUserResourceService.GetPostCountAsync"/>
        public Task<int> GetPostCountAsync()
        {
            return _repository.GetPostCountAsync();
        }

        /// <inheritdoc cref="IUserResourceService.GetPosts"/>
        public IEnumerable<UserResource> GetPosts(int pageSize, int pageNumber, SortCategory sortOption)
        {
            return _repository.GetPosts(pageSize, pageNumber, sortOption);
        }
    }
}
