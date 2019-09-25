namespace FightCore.Models.Characters
{
    /// <summary>
    /// A class to lay the link between <see cref="Combo"/> and <see cref="Character"/> this can be removed in the resource object.
    /// </summary>
    public class ComboReceiver : IEntity
    {
        /// <summary>
        /// Gets or sets an id to avoid using composite keys.
        /// They seem to do more harm than good
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the character object the combo needs to be linked to
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// Gets or sets the id of the character object
        /// </summary>
        public int CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the combo object the character needs to be linked to
        /// </summary>
        public Combo Combo { get; set; }

        /// <summary>
        /// Gets or sets the id of the combo object
        /// </summary>
        public int ComboId { get; set; }
    }
}
