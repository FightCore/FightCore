using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Characters
{
    public class DetailedCharacterResource : CharacterResource
    {
        /// <summary>
        /// Gets or sets a list of techniques the character can perform
        /// </summary>
        public List<TechniqueResource> Techniques { get; set; }

        /// <summary>
        /// Gets or sets a list of moves that a character can perform
        /// </summary>
        public List<MoveResource> Moves { get; set;}

        /// <summary>
        /// Gets or sets a collection of combos that a character can perform
        /// </summary>
        public List<DetailedComboResource> Combos { get; set; }

    }
}
