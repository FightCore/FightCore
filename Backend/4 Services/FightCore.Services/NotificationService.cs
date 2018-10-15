using FightCore.Models;
using FightCore.Repositories;
using FightCore.Services.Patterns;
using System.Collections.Generic;

namespace FightCore.Services
{
    public interface INotificationService : IEntityService<Notification>
    {
        /// <summary>
        /// Gets total count of notifications for user
        /// </summary>
        /// <param name="userId">User to get notification count for</param>
        /// <returns>Number of notifications user has</returns>
        int GetNotificationCount(int userId);

        /// <summary>
        /// Gets 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        IEnumerable<Notification> GetNotificationsForUser(int userId, int pageNumber);
    }

    public class NotificationService : EntityService<Notification>, INotificationService
    {
        private static readonly int PAGE_SIZE = 20; // Number of notifications to get per request. Note number is also in NotificationsController
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public int GetNotificationCount(int userId)
        {
            return _repository.GetNotificationsCount(userId);
        }

        public IEnumerable<Notification> GetNotificationsForUser(int userId, int pageNumber)
        {
            return _repository.GetNotificationsForUser(userId, PAGE_SIZE, pageNumber);
        }
    }
}
