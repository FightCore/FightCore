using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Characters
{
    public class DetailedCharacterResource : CharacterResource
    {
        public List<TechniqueResource> Techniques { get; set; }
        public List<MoveResource> Moves { get; set;}
        public List<ComboResource> Combos { get; set; }
    }
}
