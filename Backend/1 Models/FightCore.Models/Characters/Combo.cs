using System.Collections.Generic;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    /// <summary>
    /// A class to use for putting combos into the database
    /// </summary>
    public class Combo : IMediaEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        #region BasicInformation

        /// <summary>
        /// Gets or sets the name of the combo object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a short description of the combo to be used in listing
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author who has written down this combo
        /// </summary>
        public ApplicationUser Author { get; set; }

        /// <summary>
        /// Gets or sets the difficulty of the combo
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the category that this combo belongs to
        /// </summary>
        public ComboCategory Category { get; set; }
        #endregion

        #region Characters

        /// <summary>
        /// Gets or sets a list of characters that can perform this combo.
        /// </summary>
        public List<ComboPerformers> Performers { get; set; }

        /// <summary>
        /// Gets or sets a description of which character can perform this combo given by the user.
        /// </summary>
        public string PerformersDescription { get; set; }

        /// <summary>
        /// Gets or sets a list of characters that this combo works on.
        /// </summary>
        public List<ComboReceiver> Receivers { get; set; }

        /// <summary>
        /// Gets or sets a description of which character can receive this combo given by the user.
        /// </summary>
        public string ReceiversDescription { get; set; }
        #endregion Characters

        #region Stages

        /// <summary>
        /// Gets or sets a description detailing which stages this combo works on
        /// </summary>
        public string StagesDescription { get; set; }

        #endregion Stages

        #region Inputs

        /// <summary>
        /// Gets or sets a list of inputs that need to be done to perform this combo.
        /// </summary>
        public List<InputChain> Inputs { get; set; }

        /// <summary>
        /// Gets or sets a description of how this combo can be performed
        /// </summary>
        public string InputDescription { get; set; }

        /// <summary>
        /// Gets or sets a description about which mix-ups are available
        /// </summary>
        public string MixUpDescription { get; set; }

        #endregion Inputs

        #region Damage

        /// <summary>
        /// Gets or sets the DamageMetrics this combo can deal.
        /// A damage metrics is a list of all possible options with start and end percentages.
        /// This can be filled in by the user for combos that depend on starting damage.
        /// </summary>
        public List<DamageMetric> DamageMetrics { get; set; }

        /// <summary>
        /// Gets or sets the damage that can be done with this combo described by the user.
        /// </summary>
        public string DamageDescription { get; set; }

        #endregion Damage

        public List<Media> Media { get; set; }
    }
}
