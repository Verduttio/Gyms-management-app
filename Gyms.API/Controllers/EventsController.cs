﻿using Gyms.API.Models.Entities;
using Gyms.API.Models.Requests;
using Gyms.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gyms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController
    {
        private readonly EventsService _eventsService;

        public EventsController(EventsService eventsService)
        {
            _eventsService = eventsService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            return await _eventsService.GetEventsAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<Event> GetEventAsync(int id)
        {
            return await _eventsService.GetEventAsync(id);
        }

        // POST: api/Events
        [HttpPost]
        public async Task<Event> AddEventAsync(EventRequest eventRequest)
        {
            return await _eventsService.AddEventAsync(eventRequest);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<Event> UpdateEventAsync(int id, EventRequest eventRequest)
        {
            return await _eventsService.UpdateEventAsync(id, eventRequest);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<Event> DeleteEventAsync(int id)
        {
            return await _eventsService.DeleteEventAsync(id);
        }

    }
}