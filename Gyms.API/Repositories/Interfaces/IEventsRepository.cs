using Gyms.API.Models.Entities;

namespace Gyms.API.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<Event> GetEventAsync(int id);
        Task<Event> AddEventAsync(Event @event);
        Task<Event> UpdateEventAsync(Event @event);
        Task<Event> DeleteEventAsync(int id);
        Task<IEnumerable<Event>> GetEventsByCoachIdAsync(int coachId);
    }
}
