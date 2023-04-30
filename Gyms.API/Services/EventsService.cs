using Gyms.API.Models.Entities;
using Gyms.API.Models.Requests;
using Gyms.API.Repositories.Interfaces;
using NodaTime;

namespace Gyms.API.Services
{
    public class EventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _eventsRepository.GetEventsAsync();
        }

        public async Task<Event> GetEventAsync(int id)
        {
            return await _eventsRepository.GetEventAsync(id);
        }

        public async Task<Event> AddEventAsync(EventRequest eventRequest)
        {
            Event @event = new Event(eventRequest);
            return await _eventsRepository.AddEventAsync(@event);
        }

        public async Task<Event> UpdateEventAsync(int id, EventRequest eventRequest)
        {
            Event @event = await GetEventAsync(id);
            if(@event == null)
            {
                return null;
            }
            EventSetter(@event, eventRequest);
            return await _eventsRepository.UpdateEventAsync(@event);
        }

        public async Task<Event> DeleteEventAsync(int id)
        {
            return await _eventsRepository.DeleteEventAsync(id);
        }

        private void EventSetter(Event @event, EventRequest eventRequest)
        {
            @event.Date = DateOnly.Parse(eventRequest.Date);
            @event.Title = eventRequest.Title;
            @event.Day = eventRequest.Day;
            @event.Time = TimeOnly.Parse(eventRequest.Time);
            @event.Duration = TimeSpan.Parse(eventRequest.Duration);
            @event.ClubId = eventRequest.ClubId;
            @event.CoachId = eventRequest.CoachId;
            @event.ParticipantsLimit = eventRequest.ParticipantsLimit;
            @event.Regular = eventRequest.Regular;
            @event.ParticipantsNumber = eventRequest.ParticipantsNumber;
            @event.Cancelled = eventRequest.Cancelled;
        }
    }
}
