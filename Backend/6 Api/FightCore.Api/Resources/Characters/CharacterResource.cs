using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Games;
using FightCore.Api.Resources.Shared;

namespace FightCore.Api.Resources.Characters
{
    public class CharacterResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MediaResource> Media { get; set; }
        public GameResource Game { get; set; }
    }
}
