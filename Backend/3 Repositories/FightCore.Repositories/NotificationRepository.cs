using FightCore.Models;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace FightCore.Repositories
{
    public interface INotificationRepository : IRepositoryAsync<Notification>
    {
        int GetNotificationsCount(int userId);

        IEnumerable<Notification> GetNotificationsForUser(int userId, int pageSize, int pageNumber);
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
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }
    }
}
