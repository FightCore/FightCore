namespace FightCore.Models.Shared
{
    /// <summary>
    /// A simple controller input class.
    /// </summary>
    public class ControllerInput : IEntity
    {
        /// <inheritdoc cref="IEntity.Id"/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text description of which input on the controller is being done.
        /// </summary>
        public string TextDescription { get; set; }

        /// <summary>
        /// Gets or sets the code that the frontend uses to load the correct button images.
        /// </summary>
        public string KeyCode { get; set; }
    }
}
