using FightCore.Models.Characters;
using FightCore.Repositories.Patterns;
using FightCore.Services.Patterns;

namespace FightCore.Services.Characters
{
    public interface ICharacterService : IEntityService<Character>
    {
    }

    public class CharacterService : EntityService<Character>, ICharacterService
    {
        public CharacterService(IRepositoryAsync<Character> repository)
            : base(repository)
        {
        }
    }
}