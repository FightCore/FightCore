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
        /// <param name="type"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        Task BroadcastMessage(string type, string payload);
    }
}