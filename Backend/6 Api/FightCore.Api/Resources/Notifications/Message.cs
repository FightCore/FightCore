using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// Notification message
    /// </summary>
    public class Message
    {
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
