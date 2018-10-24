using System.Linq;

using FightCore.Models.Characters;

using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Helper.Queryable
{
    public static class CharacterQueryableHelper
    {
        public static IQueryable<Character> IncludeBasic(this IQueryable<Character> queryable)
        {
            return queryable.Include(x => x.Media).Include(x => x.Game);
        }

        public static IQueryable<Character> IncludeExpanded(this IQueryable<Character> queryable)
        {
            return queryable.Include(x => x.Media).Include(x => x.Game).ThenInclude(x => x.Media).Include(x => x.Combos)
                .Include(x => x.Moves).Include(x => x.Techniques);
        }
    }
}