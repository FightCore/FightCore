using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.Characters
{
    /// <summary>
    /// A in between class to configure the many to many relationship
    /// </summary>
    public class CharacterTechnique : IEntity
    {
        /// <summary>
        /// Gets or sets the Id of the linking object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the character that the technique is linked to.
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// Gets or sets the Id of the <see cref="Character"/> object that the technique is linked to.
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the technique that the character is linked to.
        /// </summary>
        public Technique Technique { get; set; }

        /// <summary>
        /// Gets or sets the Id of the <see cref="Technique"/> object the character is linked to.
        /// </summary>
        public int TechniqueId { get; set; }
    }
}
