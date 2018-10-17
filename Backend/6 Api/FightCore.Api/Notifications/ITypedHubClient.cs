using FightCore.Api.Resources.Notifications;
using System.Threading.Tasks;

namespace FightCore.Api.Notifications
{
    /// <summary>
    /// Defines SignalR client interaction methods
    /// </summary>
    public interface ITypedHubClient
    {
        /// <summary>
        /// Send a notification
        /// </summary>
        /// <param name="notification">Notification to send</param>
        /// <returns>An awaitable Task</returns>
        Task BroadcastNotification(NotificationResultResource notification);
    }
}