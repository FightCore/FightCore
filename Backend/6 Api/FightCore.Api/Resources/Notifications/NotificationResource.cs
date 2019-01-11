using System;

namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// UI Resource of the <see cref="Models.Notification"/> class
    /// </summary>
    public class NotificationResource
    {
        /// <summary>
        /// The user this notification is for.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The title of the notification.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content of the notification.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The on-site relative link for where this notification should lead to.
        /// </summary>
        public string RouteLink { get; set; }

        /// <summary>
        /// The flat that determines if this notification is important or not.
        /// </summary>
        public bool IsImportant { get; set; }
    }

    /// <summary>
    /// Describes the server response for a single notification
    /// </summary>
    public class NotificationResultResource : NotificationResource
    {
        /// <summary>
        /// The id of this notification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// When this notification was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// When this notification was actually read by the user.
        /// </summary>
        public DateTime? ReadDate { get; set; }
    }
}
