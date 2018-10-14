using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.Notifications
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class NotifyHub: Hub<ITypedHubClient>
    {
    }
}
