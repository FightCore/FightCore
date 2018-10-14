using FightCore.Models;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Repositories
{
    public interface INotificationRepository : IRepositoryAsync<Notification>
    {

    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbContext context) : base(context)
        {

        }
    }
}
