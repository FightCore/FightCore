using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.Notifications
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity.Name;
        }
    }
}
