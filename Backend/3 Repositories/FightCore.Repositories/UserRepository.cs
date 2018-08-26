using FightCore.Data;
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
		public UserRepository(DbContext context) : base(context)
		{
			
		}
	}
}