using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FightCore.Repositories.PlayerStatistics
{
    /// <summary>
    /// Repository interface for Entity <see cref="FightCore.Models.PlayerStatistics.Event"/>
    /// </summary>
    public interface IEventRepository : IRepositoryAsync<Event>
    {
        Task<List<Event>> GetAllEventsWithMediaAsync();
        Task<Event> GetDetailedEventByIdAsync(int eventId);
        Event GetDetailedEventById(int eventId);
    }

    public class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(DbContext context) : base(context)
        {
        }

        public Task<List<Event>> GetAllEventsWithMediaAsync()
        {
            return Queryable.Include(x => x.Media).ToListAsync();
        }

        public Task<Event> GetDetailedEventByIdAsync(int eventId)
        {
            return Queryable
                .Include(x => x.Media)
                .FirstOrDefaultAsync(x => x.Id == eventId);
        }

        public Event GetDetailedEventById(int eventId)
        {
            return Queryable
                .Include(x => x.Media)
                .FirstOrDefault(x => x.Id == eventId);
        }

    }
}
