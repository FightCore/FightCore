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

        /// <summary>
        /// Gets or sets the name of the character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the character
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a collection of media objects belonging to the character
        /// </summary>
        public List<MediaResource> Media { get; set; }

        /// <summary>
        /// Gets or sets the game that this character belongs to
        /// </summary>
        public GameResource Game { get; set; }
    }
}
