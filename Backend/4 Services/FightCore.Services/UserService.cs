using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Repositories;
using FightCore.Services.Patterns;

namespace FightCore.Services
{
	public interface IUserService : IEntityService<ApplicationUser>
	{
	}

	public class UserService : EntityService<ApplicationUser>, IUserService
	{
		private readonly IUserRepository _techniqueRepository;
		
		public UserService(IUserRepository techniqueRepository) : base(techniqueRepository)
		{
			_techniqueRepository = techniqueRepository;
		}
	}
}