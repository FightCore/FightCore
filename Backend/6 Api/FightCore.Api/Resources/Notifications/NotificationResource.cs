using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// UI Resource of the <see cref="FightCore.Models.Notification"/> class
    /// </summary>
    public class NotificationResource
    {
        /// <summary>
        /// The user this notification is for
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Title of the notification
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content of the notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// On-site relative link for where this notification should lead to
        ///TODO: Remove from being directly set by a request
        /// </summary>
        public string RouteLink { get; set; }

        /// <summary>
        /// Determines if this notification is important or not
        /// </summary>
        public bool IsImportant { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NotificationResultResource : NotificationResource
    {
        public int Id { get; set; }

        /// <summary>
        /// When this notification was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// When this notification was actually read by end user
        /// </summary>
        public DateTime? ReadDate { get; set; }
    }
}
