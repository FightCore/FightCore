using System;

namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// UI Resource of the <see cref="Models.Notification"/> class
    /// </summary>
    public class NotificationResource
    {
        /// <summary>
        /// Gets or sets the user this notification is for
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the title of the notification
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the on-site relative link for where this notification should lead to
        /// </summary>
        public string RouteLink { get; set; }

        /// <summary>
        /// Gets or sets the flat that determines if this notification is important or not
        /// </summary>
        public bool IsImportant { get; set; }
    }

    /// <summary>
    /// Describes the server response for a single notification
    /// </summary>
    public class NotificationResultResource : NotificationResource
    {
        /// <summary>
        /// Gets or sets the id of this notification
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets when this notification was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets when this notification was actually read by the user
        /// </summary>
        public DateTime? ReadDate { get; set; }
    }
}
