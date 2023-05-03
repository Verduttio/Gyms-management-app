using Gyms.API.Models.Entities;
using Microsoft.CodeAnalysis;

namespace Gyms.API.Services.Validators
{
    public class ReservationsValidator
    {
        private readonly EventsService _eventsService;

        public ReservationsValidator(EventsService eventsService)
        {
            _eventsService = eventsService;
        }

        public async Task<bool> IsFreePlace(int eventId)
        {
            Event @event = await _eventsService.GetEventAsync(eventId);
            if(@event != null)
            {
                return @event.ParticipantsNumber < @event.ParticipantsLimit;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EventCancelled(int eventId)
        {
            Event @event = await _eventsService.GetEventAsync(eventId);
            if(@event != null)
            {
                return @event.Cancelled;
            }
            else
            {
                return false;
            }
        }

        public async Task IncrementReservationsNumber(int eventId)
        {
            await _eventsService.IncrementParticipantsNumber(eventId);
        }

        public async Task DecrementReservationsNumber(int eventId)
        {
            await _eventsService.DecrementParticipantsNumber(eventId);
        }
    }
}
