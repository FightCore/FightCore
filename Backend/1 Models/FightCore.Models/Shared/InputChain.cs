using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Characters;

namespace FightCore.Models.Shared
{
    /// <summary>
    /// A class to indicate an order of either moves, techniques or inputs that need to be done to perform an action
    /// </summary>
    public class InputChain : IEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the move that needs to be done
        /// </summary>
        public Move Move { get; set; }

        /// <summary>
        /// Gets or sets the technique that needs to be done
        /// </summary>
        public Technique Technique { get; set; }

        /// <summary>
        /// Gets or sets a controller input that can needs to be done
        /// </summary>
        public ControllerInput Input { get; set; }

        /// <summary>
        /// Gets or sets the first frame that this input will chain with the previous
        /// </summary>
        public int FirstFrame { get; set; }

        /// <summary>
        /// Gets or sets the last frame that this input will chain with the previous
        /// </summary>
        public int LastFrame { get; set; }
    }
}
