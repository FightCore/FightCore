namespace FightCore.Models.Characters
{
    using System.Collections.Generic;
    using FightCore.Models.Shared;

    /// <summary>
    /// A class to store information about a character from a game.
    /// </summary>
    public class Character : IMediaEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a list of combos that this character can perform
        /// </summary>
        public List<ComboPerformers> Combos { get; set; }

        /// <summary>
        /// Gets or sets a description of the character object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Game"/> object that this character appears is from
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets the Id of the <see cref="Game"/> entity
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets a list of media objects related to this character
        /// </summary>
        public List<Media> Media { get; set; }

        /// <summary>
        /// Gets or sets a list of moves that this character can perform.
        /// </summary>
        public List<Move> Moves { get; set; }

        /// <summary>
        /// Gets or sets the name of this character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of techniques this character can perform
        /// </summary>
        public List<CharacterTechnique> Techniques { get; set; }
    }
}