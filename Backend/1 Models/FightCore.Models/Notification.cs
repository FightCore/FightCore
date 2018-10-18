using System;

namespace FightCore.Models
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the user this notification is for
        /// </summary>
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets when this notification was created
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Gets or sets when this notification was actually read by the user
        /// </summary>
        public DateTime? ReadDate { get; set; }

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
        /// Security: Be careful with this field, otherwise we may expose security vulnerabilities
        /// Should not be directly set by a request
        /// </summary>
        public string RouteLink { get; set; }

        /// <summary>
        /// Gets or sets the flag to determine if this notification is important or not
        /// </summary>
        public bool IsImportant { get; set; }
    }
}
