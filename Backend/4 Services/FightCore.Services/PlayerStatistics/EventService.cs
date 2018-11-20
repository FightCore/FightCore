using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using FightCore.Repositories.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    public interface IEventService : IEntityService<Event>
    {
        Task<List<Event>> GetAllEventsAsync();
    }
    public class EventService : EntityService<Event>, IEventService
    {
        private readonly IEventRepository _repository;
        public EventService(IEventRepository repository) : base((IRepositoryAsync<Event>)repository)
        {
            _repository = repository;
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            return _repository.GetAllEventsWithMediaAsync();
        }

        public override Task<Event> FindByIdAsync(int EventId)
        {
            return _repository.GetDetailedEventByIdAsync(EventId);
        }

        public override Event FindById(int EventId)
        {
            return _repository.GetDetailedEventById(EventId);
        }

    }
}
