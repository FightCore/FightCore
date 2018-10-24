using System.Linq;

using FightCore.Models;

using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Helper.Queryable
{
    public static class GameQueryableHelper
    {
        public static IQueryable<Game> IncludeMedia(this IQueryable<Game> queryable)
        {
            return queryable.Include(x => x.Media);
        }
    }
}
