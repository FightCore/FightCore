using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.Notifications
{
    public class UserIdProvider : IUserIdProvider
    {
        /// <summary>
        /// Standard method for identifying a specific client for SignalR
        /// </summary>
        /// <param name="connection">Client connection</param>
        /// <returns>Unique identifying info for user</returns>
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity.Name; // This is actually the UserId in reality
        }
    }
}
