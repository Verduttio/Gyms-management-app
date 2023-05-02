using Gyms.API.Models.Entities;
using Gyms.Models.Dtos.Requests;
using Gyms.API.Repositories.Interfaces;
using Gyms.API.Services.Validators;
using NodaTime;
using System.Collections.Generic;

namespace Gyms.API.Services
{
    public class EventsService
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly EventsValidator _eventsValidator;

        public EventsService(IEventsRepository eventsRepository, EventsValidator eventsValidator)
        {
            _eventsRepository = eventsRepository;
            _eventsValidator = eventsValidator;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _eventsRepository.GetEventsAsync();
        }

        public async Task<Event> GetEventAsync(int id)
        {
            return await _eventsRepository.GetEventAsync(id);
        }

        public async Task<Event?> AddEventAsync(EventRequest eventRequest)
        {
            Event @event = new Event(eventRequest);
            IEnumerable<Event> coachEvents = (await GetEventsByCoachIdAsync(@event.CoachId));
            if (await _eventsValidator.EventInClubOpeningHours(@event.ClubId, @event.Day, @event.Time, @event.Duration) &&
                _eventsValidator.CoachFree(coachEvents, @event.Date, @event.Time, @event.Duration))
            {
                return await _eventsRepository.AddEventAsync(@event);
            }
            return null;
        }



        public async Task<Event?> UpdateEventAsync(int id, EventRequest eventRequest)
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

        public async Task<IEnumerable<Event>> GetEventsByCoachIdAsync(int coachId)
        {
            return await _eventsRepository.GetEventsByCoachIdAsync(coachId);
        }

        public async Task IncrementParticipantsNumber(int id)
        {
            Event @event = await GetEventAsync(id);
            if(@event != null)
            {
                @event.ParticipantsNumber++;
                await _eventsRepository.UpdateEventAsync(@event);
            }
        }

        public async Task DecrementParticipantsNumber(int id)
        {
            Event @event = await GetEventAsync(id);
            if(@event != null)
            {
                @event.ParticipantsNumber--;
                await _eventsRepository.UpdateEventAsync(@event);
            }
        }

        public async Task CancelEvent(int id)
        {
            Event @event = await GetEventAsync(id);
            if(@event != null)
            {
                @event.Cancelled = true;
                await _eventsRepository.UpdateEventAsync(@event);
            }
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

        internal Task<IEnumerable<Event>> GetEventsByClubIdAsync(int clubId)
        {
            return _eventsRepository.GetEventsByClubIdAsync(clubId);
        }
    }
}
