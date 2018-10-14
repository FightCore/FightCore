namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// Notification message for a specific user
    /// </summary>
    public class UserMessage
    {
        /// <summary>
        /// User to send message to
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Type of notification
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Body of notification
        /// </summary>
        public string Payload { get; set; }
    }
}
