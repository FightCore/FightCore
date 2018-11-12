using System.Collections.Generic;
using FightCore.Models.User;
using Microsoft.AspNetCore.Identity;

namespace FightCore.Models
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
        public string Bio { get; set; }

        public List<UserCharacter> FavoriteCharacters { get; set; }

        public List<UserGame> FavoriteGames { get; set; }
    }
}
