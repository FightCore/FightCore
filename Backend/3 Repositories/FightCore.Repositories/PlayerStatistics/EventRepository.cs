﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FightCore.Repositories.PlayerStatistics
{
    public interface IEventRepository : IRepositoryAsync<Event>
    {
        Task<List<Event>> GetAllEventsWithMediaAsync();
        Task<Event> GetDetailedEventByIdAsync(int EventId);
        Event GetDetailedEventById(int EventId);
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

        public Task<Event> GetDetailedEventByIdAsync(int EventId)
        {
            return Queryable
                .Include(x => x.Media)
                .FirstOrDefaultAsync(x => x.Id == EventId);
        }

        public Event GetDetailedEventById(int EventId)
        {
            return Queryable
                .Include(x => x.Media)
                .FirstOrDefault(x => x.Id == EventId);
        }

    }
}