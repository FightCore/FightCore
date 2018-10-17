using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.Notifications
{
    /// <summary>
    /// Defines SignalR hub used for pushing content to clients
    /// </summary>
    [Authorize]
    public class NotifyHub: Hub<ITypedHubClient>
    {
    }
}
