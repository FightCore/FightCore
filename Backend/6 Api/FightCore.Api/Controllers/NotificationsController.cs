using System;
using FightCore.Api.Notifications;
using FightCore.Api.Resources.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.SignalRTesting
{
    /// <summary>
    /// Temporary testing api for notifications
    /// This comment should NOT make it to merge phase
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="hubContext"></param>
        public NotificationsController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        /// <summary>
        /// Test notification
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>Returns something</returns>
        [HttpPost]
        public string BroadcastToAll([FromBody]Message msg)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.All.BroadcastMessage(msg.Type, msg.Payload);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }

        /// <summary>
        /// Test notification to a specific user
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>Returns something</returns>
        [HttpPost]
        public string PrivateMessage([FromBody]UserMessage msg)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.User(msg.UserId).BroadcastMessage(msg.Type, msg.Payload);

                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}