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
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        Task BroadcastNotification(NotificationResultResource notification);
    }
}