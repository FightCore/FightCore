using FightCore.Models;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories
{
	public interface IUserRepository : IRepositoryAsync<ApplicationUser>
    {
	}

	public class UserRepository : Repository<ApplicationUser>, IUserRepository
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context wanted to inserted</param>
        /// <inheritdoc/>
		public UserRepository(DbContext context) : base(context)
		{
		}
	}
}