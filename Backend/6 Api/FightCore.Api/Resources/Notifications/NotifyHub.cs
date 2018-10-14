using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FightCore.Api.Resources.Notifications
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class NotifyHub: Hub<ITypedHubClient>
    {
    }
}
