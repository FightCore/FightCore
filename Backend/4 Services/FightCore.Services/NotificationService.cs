using FightCore.Models;
using FightCore.Repositories;
using FightCore.Services.Patterns;

namespace FightCore.Services
{
    public interface INotificationService : IEntityService<Notification>
    {
    }

    public class NotificationService : EntityService<Notification>, INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
