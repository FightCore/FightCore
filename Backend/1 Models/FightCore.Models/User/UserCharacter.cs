using System.ComponentModel.DataAnnotations;

using FightCore.Models.Characters;

namespace FightCore.Models.User
{
    public class UserCharacter
    {
        public ApplicationUser User { get; set; }

        public int UserId { get; set; }

        public Character Character { get; set; }

        public int CharacterId { get; set; }

        public UserCharacter()
        {
        }

        public UserCharacter(ApplicationUser user, Character character)
        {
            User = user;
            UserId = user.Id;
            Character = character;
            CharacterId = character.Id;
        }
    }
}
