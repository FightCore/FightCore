using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    public class Move : IMediaEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the move
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the move
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets what character can do the move
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// Gets or sets the input that needs to be done to perform this move.
        /// </summary>
        public ControllerInput Input { get; set; }

        /// <summary>
        /// Gets or sets a collection of media objects to go along this move.
        /// </summary>
        public List<Media> Media { get; set; }
    }
}
