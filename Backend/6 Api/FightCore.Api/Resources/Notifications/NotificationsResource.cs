using System.Collections.Generic;

namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// Details response for returning a group of notifications to client
    /// </summary>
    public class NotificationsResource
    {
        /// <summary>
        /// Gets or sets the total number of notifications the relevant user has
        /// </summary>
        public int TotalNotifications { get; set; }

        /// <summary>
        /// Gets or sets the current page index of notifications, 20 per page, 1 is first page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the retrieved notifications for this page
        /// </summary>
        public ICollection<NotificationResultResource> Notifications { get; set; }
    }
}
