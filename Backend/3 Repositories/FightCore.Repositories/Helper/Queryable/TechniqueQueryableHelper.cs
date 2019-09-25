using FightCore.Models.Characters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FightCore.Repositories.Helper.Queryable
{
    public static class TechniqueQueryableHelper
    {
        public static IQueryable<Technique> IncludeBasic(this IQueryable<Technique> queryable)
        {
            return queryable.Include(x => x.Game).Include(x => x.Media).Include(x => x.Author);
        }

        /// <summary>
        /// Includes all the needed except the <see cref="Technique.Inputs"/> object as this is too complex to give to the frontend.
        /// </summary>
        /// <param name="queryable">The queryable wanting to be expanded</param>
        /// <returns>the expanded queryable</returns>
        public static IQueryable<Technique> IncludeExpanded(this IQueryable<Technique> queryable)
        {
            return queryable.Include(x => x.Game).ThenInclude(x => x.Media).Include(x => x.Media)
                .Include(x => x.Characters).ThenInclude(y => y.Character).ThenInclude(x => x.Media);
        }
    }
}