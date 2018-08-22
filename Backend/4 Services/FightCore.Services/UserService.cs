using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Repositories;
using FightCore.Services.Patterns;

namespace FightCore.Services
{
	public interface IUserService : IService<ApplicationUser>
	{
		Task<ApplicationUser> FindByIdAsync(string id);
	}

	public class UserService : Service<ApplicationUser>, IUserService
	{
		private readonly IUserRepository _repository;
		
		public UserService(IUserRepository repository) : base(repository)
		{
			_repository = repository;
		}

		public Task<ApplicationUser> FindByIdAsync(string id)
		{
			return _repository.FindAsync(a => a.Id.Equals(id));
		}
	}
}