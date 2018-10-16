using FightCore.Models;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace FightCore.Repositories
{
    public interface INotificationRepository : IRepositoryAsync<Notification>
    {
        int GetNotificationsCount(int userId);

        IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber);

        void MarkAllUnreadRead(int userId);
    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly DbSet<Notification> _dbSet;
        public NotificationRepository(DbContext context) : base(context)
        {
            _dbSet = context.Set<Notification>();
        }

        public virtual int GetNotificationsCount(int userId)
        {
            return _dbSet.Where(x => x.UserId == userId).Count();
        }

        public virtual IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber)
        {
            return _dbSet
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedDate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

        public virtual void MarkAllUnreadRead(int userId)
        {
            _dbSet
                .Where(x => x.UserId == userId && x.ReadDate == null)
                .ToList()
                .ForEach(x => x.ReadDate = DateTime.Now);
        }
    }
}
