using System.Collections.Generic;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    /// <summary>
    /// A class for techniques that characters can perform in fighting games.
    /// Techniques are defined as a chain of inputs that have a special interaction in-game.
    /// This is not a string of inputs that goes into a set combo (Example Street Fighter's hadouken move.
    /// Examples of techniques are waveshine, wavedash, edge cancel, etc.
    /// </summary>
    public class Technique : IMediaEntity
    {
        /// <summary>
        /// Gets or sets the Id that is the primary Id of this entity.
        /// Derived from <see cref="IEntity"/>
        /// </summary>
        public int Id { get; set; }

        #region BasicInformation
        /// <summary>
        /// Gets or sets the name of the tech being described
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a basic description of the technique
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the game that this tech can be performed in
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets a collection of media that belongs to this technique
        /// </summary>
        public List<Media> Media { get; set; }

        /// <summary>
        /// Gets or sets the user who was written out this technique
        /// </summary>
        public ApplicationUser Author { get; set; }
        #endregion BasicInformation

        #region InputInformation
        /// <summary>
        /// Gets or sets the inputs required to do this technique.
        /// Can be NULL if the user is only using <see cref="ExecuteDescription"/>
        /// </summary>
        public List<InputChain> Inputs { get; set; }

        /// <summary>
        /// Gets or sets the user written text about how this technique should be executed.
        /// If a user only uses <see cref="Inputs"/> this can be NULL.
        /// </summary>
        public string ExecuteDescription { get; set; }

        #endregion InputInformation

        #region Characters

        /// <summary>
        /// Gets or sets the characters that can perform this technique
        /// </summary>
        public List<CharacterTechnique> Characters { get; set; }

        /// <summary>
        /// Gets or sets a string description about which characters can perform this technique.
        /// Given by the user.
        /// </summary>
        public string CharactersDescription { get; set; }

        #endregion Characters

        #region Stage

        /// <summary>
        /// Gets or sets the description of which stages this tech can be executed on.
        /// This value is given by the user and can be null
        /// </summary>
        public string StagesDescription { get; set; }

        #endregion Stage

        #region AdvancedInformation

        /// <summary>
        /// Gets or sets a detailed description about the technique.
        /// </summary>
        public string DetailedDescription { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the technique being performed.
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// Gets or sets a string describing when the technique should be used.
        /// </summary>
        public string Application { get; set; }
        #endregion
    }
}
