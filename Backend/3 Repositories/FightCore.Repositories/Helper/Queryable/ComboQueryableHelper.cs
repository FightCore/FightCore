using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FightCore.Models.Characters;

using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories.Helper.Queryable
{
    public static class ComboQueryableHelper
    {
        public static IQueryable<Combo> IncludeBasic(this IQueryable<Combo> queryable)
        {
            return queryable.Include(x => x.Author).Include(x => x.Media);
        }

        public static IQueryable<Combo> IncludeExpanded(this IQueryable<Combo> queryable)
        {
            return queryable.Include(x => x.Author).Include(x => x.Media)
                .Include(x => x.DamageMetrics).Include(x => x.Inputs)
                .Include(x => x.Performers).ThenInclude(x => x.Character)
                .Include(x => x.Receivers).ThenInclude(x => x.Character);
        }
    }
}
