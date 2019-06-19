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
        /// <summary>
        /// Gets the amount of notifications by user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>An awaitable task with the result being the amount of notifications.</returns>
        Task<int> GetNotificationsCountAsync(int userId);

        /// <summary>
        /// Gets the notifications for an user.
        /// </summary>
        /// <param name="userId">The user id wanting to be searched for.</param>
        /// <param name="pageSize">The amount of items wanting to be gathered.</param>
        /// <param name="pageNumber">The page wanting to be gained.</param>
        /// <returns>A collection of <see cref="Notification"/> objects.</returns>
        IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber);

        /// <summary>
        /// Marks all unread notifications as read.
        /// </summary>
        /// <param name="userId">The user wanting to mark all notifications read for.</param>
        /// <returns>An awaitable task.</returns>
        Task MarkAllUnreadReadAsync(int userId);
    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository" /> class.
        /// </summary>
        /// <param name="context">The context wanting to be inserted.</param>
        public NotificationRepository(DbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public Task<int> GetNotificationsCountAsync(int userId)
        {
            return Queryable.CountAsync(x => x.UserId == userId);
        }

        /// <inheritdoc />
        public IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber)
        {
            return Queryable
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedDate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

        /// <inheritdoc />
        public async Task MarkAllUnreadReadAsync(int userId)
        {
            var notifications = await Queryable
                .Where(x => x.UserId == userId && x.ReadDate == null)
                .ToListAsync();

            notifications.ForEach(x => x.ReadDate = DateTime.Now);
        }
    }
}
