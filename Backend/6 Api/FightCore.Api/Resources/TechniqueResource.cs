using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Games;
using FightCore.Api.Resources.Shared;
using FightCore.Models.Shared;

namespace FightCore.Api.Resources
{
    public class TechniqueResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GameResource Game { get; set; }
        public List<MediaResource> Media { get; set; }
        public List<InputChainResource> Inputs { get; set; }
    }
}
