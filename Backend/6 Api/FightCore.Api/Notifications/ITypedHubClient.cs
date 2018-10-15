using FightCore.Api.Resources.Notifications;
using System.Threading.Tasks;

namespace FightCore.Api.Notifications
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITypedHubClient
    {
        /// <summary>
        /// Send a notification
        /// </summary>
        /// <param name="notification">Notification to send</param>
        /// <returns></returns>
        Task BroadcastNotification(NotificationResultResource notification);
    }
}