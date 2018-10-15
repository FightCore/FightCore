using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Notifications
{
    public class NotificationsResource
    {
        /// <summary>
        /// Total number of notifications the relevant user has
        /// </summary>
        public int TotalNotifications { get; set; }

        /// <summary>
        /// Current page of notifications, 20 per page, 1 is first page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Retrieved notifications for this page
        /// </summary>
        public ICollection<NotificationResultResource> Notifications { get; set; }
    }
}
