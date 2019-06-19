
using FightCore.Api.Resources.Notifications;

using Swashbuckle.AspNetCore.Filters;

namespace FightCore.Api.Examples
{
    public class NotificationResourceExample : IExamplesProvider<NotificationResource>
    {
        public NotificationResource GetExamples()
        {
            return new NotificationResource()
            {
                Content = "Bort has made a new post, titled ",
                IsImportant = true,
                RouteLink = "https://www.fightcore.org/library/1/bort-post",
                Title = "Bort made a post",
                UserId = 1
            };
        }
    }
}
