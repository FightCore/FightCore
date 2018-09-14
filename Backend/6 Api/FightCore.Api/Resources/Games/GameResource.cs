using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Shared;

namespace FightCore.Api.Resources.Games
{
    public class GameResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<MediaResource> Media { get; set; }
    }
}
