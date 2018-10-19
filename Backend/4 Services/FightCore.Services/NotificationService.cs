using FightCore.Models;
using FightCore.Repositories;
using FightCore.Services.Patterns;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FightCore.Services
{
    public interface INotificationService : IEntityService<Notification>
    {
        /// <summary>
        /// Gets total count of notifications for user
        /// </summary>
        /// <param name="userId">User to get notification count for</param>
        /// <returns>Number of notifications user has</returns>
        Task<int> GetNotificationsCountAsync(int userId);

        /// <summary>
        /// Gets notifications for user one page at a time
        /// </summary>
        /// <param name="userId">User to get notifications for</param>
        /// <param name="pageSize">Number of notifications per page</param>
        /// <param name="pageNumber">Page of notifications to retrieve (starting at 1)</param>
        /// <returns></returns>
        IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber);

        /// <summary>
        /// Marks all unread notifications for a user as read
        /// </summary>
        /// <param name="userId">User whose notifications should be now all read</param>
        Task MarkAllUnreadReadAsync(int userId);
    }

    public class NotificationService : EntityService<Notification>, INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        /// <inheritdoc cref="INotificationService.GetNotificationsCountAsync"/>
        public Task<int> GetNotificationsCountAsync(int userId)
        {
            return _repository.GetNotificationsCountAsync(userId);
        }

        /// <inheritdoc cref="INotificationService.GetNotificationsForUser"/>
        public IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber)
        {
            return _repository.GetNotificationsForUser(userId, pageSize, pageNumber);
        }

        /// <inheritdoc cref="INotificationService.MarkAllUnreadReadAsync"/>
        public Task MarkAllUnreadReadAsync(int userId)
        {
            return _repository.MarkAllUnreadReadAsync(userId);
        }
    }
}
