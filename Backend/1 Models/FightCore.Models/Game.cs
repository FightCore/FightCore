using System.Collections.Generic;
using FightCore.Models.Shared;

namespace FightCore.Models
{
    public class Game : IEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the official name of the game
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation to indicate this game.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets a collection of media objects that belong to this game
        /// </summary>
        public List<Media> Media { get; set; }
    }
}
