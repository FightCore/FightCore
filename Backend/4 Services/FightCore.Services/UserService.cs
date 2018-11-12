using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.User;
using FightCore.Repositories;
using FightCore.Services.Patterns;

namespace FightCore.Services
{
	public interface IUserService : IEntityService<ApplicationUser>
	{
        /// <summary>
        /// Updates the user by updating the bio, adding favorite games and characters.
        /// </summary>
        /// <param name="user">The user wanting to be updated</param>
        /// <param name="games">A collection of games that will be the favorite games</param>
        /// <param name="characters">A collection of characters that will be the favorite characters</param>
        /// <param name="bio">The user's bio</param>
	    void UpdateUserForMetaData(ApplicationUser user, IEnumerable<Game> games, IEnumerable<Character> characters, string bio);
	}

	public class UserService : EntityService<ApplicationUser>, IUserService
	{
		private readonly IUserRepository _repository;

		public UserService(IUserRepository repository) : base(repository)
		{
			_repository = repository;
		}

	    /// <inheritdoc cref="IUserService.UpdateUserForMetaData"/>
	    public void UpdateUserForMetaData(ApplicationUser user, IEnumerable<Game> games, IEnumerable<Character> characters, string bio)
	    {
	        if (!string.IsNullOrWhiteSpace(bio))
	        {
	            user.Bio = bio;
            }

	        user.FavoriteGames = new List<UserGame>();
            foreach (var game in games)
            {
                user.FavoriteGames.Add(new UserGame(user, game));
            }

            user.FavoriteCharacters = new List<UserCharacter>();
	        foreach (var character in characters)
	        {
	            user.FavoriteCharacters.Add(new UserCharacter(user, character));
	        }

	        _repository.Update(user);
	    }
	}
}