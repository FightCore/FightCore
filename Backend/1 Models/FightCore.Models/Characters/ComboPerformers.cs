namespace FightCore.Models.Characters
{
    /// <summary>
    /// A class to link characters to objects that can execute a combo.
    /// This could not be worked into one generic object with <see cref="ComboReceiver"/> as EF will not know who is receiving the combo.
    /// There has been chosen to not work with a Receive/Execute bool to make it easier on building the resource objects.
    /// </summary>
    public class ComboPerformers : IEntity
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
