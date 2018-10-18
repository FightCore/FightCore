using FightCore.Models;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace FightCore.Repositories
{
    public interface INotificationRepository : IRepositoryAsync<Notification>
    {
        Task<int> GetNotificationsCount(int userId);

        IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber);

        void MarkAllUnreadRead(int userId);
    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GetNotificationsCount(int userId)
        {
            return await Queryable.CountAsync(x => x.UserId == userId);
        }

        public IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber)
        {
            return Queryable
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedDate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

        public async void MarkAllUnreadRead(int userId)
        {
            var notifications = await Queryable
                .Where(x => x.UserId == userId && x.ReadDate == null)
                .ToListAsync();

            notifications.ForEach(x => x.ReadDate = DateTime.Now);
        }
    }
}
