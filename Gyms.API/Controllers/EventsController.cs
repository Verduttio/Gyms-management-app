using Gyms.API.Models.Entities;
using Gyms.Models.Dtos.Requests;
using Gyms.API.Services;
using Microsoft.AspNetCore.Mvc;
using Gyms.Models.Dtos.Responses;

namespace Gyms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsService _eventsService;

        public EventsController(EventsService eventsService)
        {
            _eventsService = eventsService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IEnumerable<EventResponse?>> GetEventsAsync()
        {
            IEnumerable<Event> events = await _eventsService.GetEventsAsync();
            IEnumerable<EventResponse?> eventResponses = events.Select(e => Event.MakeEventResponse(e)).ToList();

            return eventResponses;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<EventResponse?> GetEventAsync(int id)
        {
            Event @event = await _eventsService.GetEventAsync(id);
            EventResponse? eventResponse = Event.MakeEventResponse(@event);

            return eventResponse;
        }

        // POST: api/Events
        [HttpPost]
        public async Task<EventResponse?> AddEventAsync(EventRequest eventRequest)
        {
            Event? @event = await _eventsService.AddEventAsync(eventRequest);
            EventResponse? eventResponse = Event.MakeEventResponse(@event);

            return eventResponse;
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<EventResponse> UpdateEventAsync(int id, EventRequest eventRequest)
        {
            Event @event = await _eventsService.UpdateEventAsync(id, eventRequest);
            EventResponse? eventResponse = Event.MakeEventResponse(@event);

            return eventResponse;
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<EventResponse> DeleteEventAsync(int id)
        {
            Event @event = await _eventsService.DeleteEventAsync(id);
            EventResponse? eventResponse = Event.MakeEventResponse(@event);

            return eventResponse;
        }

        // GET: api/Events/Coach/5
        [HttpGet("Coach/{coachId}")]
        public async Task<IEnumerable<EventResponse?>> GetEventsByCoachIdAsync(int coachId)
        {
            IEnumerable<Event> events = await _eventsService.GetEventsByCoachIdAsync(coachId);
            IEnumerable<EventResponse?> eventResponses = events.Select(e => Event.MakeEventResponse(e)).ToList();

            return eventResponses;
        }

        // GET: api/Events/Club/5
        [HttpGet("Club/{clubId}")]
        public async Task<IEnumerable<EventResponse?>> GetEventsByClubIdAsync(int clubId)
        {
            IEnumerable<Event> events = await _eventsService.GetEventsByClubIdAsync(clubId);
            IEnumerable<EventResponse?> eventResponses = events.Select(e => Event.MakeEventResponse(e)).ToList();
            return eventResponses;
        }

    }
}
