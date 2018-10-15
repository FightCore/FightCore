using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// The user this notification is for
        /// </summary>
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// When this notification was created
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// When this notification was actually read by end user
        /// </summary>
        public DateTime? ReadDate { get; set; }

        /// <summary>
        /// Title of the notification
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The content of the notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// On-site relative link for where this notification should lead to
        /// Security: Be careful with this field, otherwise we may expose security vulnerabilities
        /// Should not be directly set by a request
        /// </summary>
        public string RouteLink { get; set; }
        /// <summary>
        /// Determines if this notification is important or not
        /// </summary>
        public bool IsImportant { get; set; }
    }
}
