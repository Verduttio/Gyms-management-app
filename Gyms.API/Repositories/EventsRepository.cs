using Gyms.API.Data;
using Gyms.API.Models.Entities;
using Gyms.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gyms.API.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly DataContext _context;

        public EventsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Event> AddEventAsync(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return @event;
        }

        public async Task<Event> DeleteEventAsync(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return @event;
        }

        public async Task<Event> GetEventAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByCoachIdAsync(int coachId)
        {
            return await _context.Events.Where(e => e.CoachId == coachId).ToListAsync();
        }

        public async Task<Event> UpdateEventAsync(Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return @event;
        }
    }
}
