using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources
{
    public class UserMetaDataResource
    {
        public string Bio { get; set; }
        public List<int> FavoriteGames { get; set; }

        public List<int> FavoriteCharacters { get; set; }
    }
}
