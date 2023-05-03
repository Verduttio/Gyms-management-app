﻿using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;

namespace Gyms.UI.Services
{
    public class EventsService : IEventsService
    {

        private readonly HttpClient _httpClient;

        public EventsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EventResponse> GetEvent(int id)
        {
            try
            {
                var @event = await _httpClient.GetFromJsonAsync<EventResponse>($"api/Events/{id}");
                return @event;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting event", ex);
            }
        }

        public async Task<IEnumerable<EventResponse>> GetEvents()
        {
            try
            {
                var events = await _httpClient.GetFromJsonAsync<IEnumerable<EventResponse>>("api/Events");
                return events;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting events", ex);
            }
        }
        public async Task<IEnumerable<EventResponse>> GetCoachEvents(int coachId)
        {
            try
            {
                var coachEvents = await _httpClient.GetFromJsonAsync<IEnumerable<EventResponse>>($"api/Events/Coach/{coachId}");
                return coachEvents;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting coach events", ex);
            }
        }

        public async Task<EventResponse> DeleteEvent(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Events/{id}");
                var @event = await response.Content.ReadFromJsonAsync<EventResponse>();
                return @event;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting event", ex);
            }
        }

        public async Task<IEnumerable<EventResponse>> GetClubEvents(int clubId)
        {
            try
            {
                var clubEvents = await _httpClient.GetFromJsonAsync<IEnumerable<EventResponse>>($"api/Events/Club/{clubId}");
                return clubEvents;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting club events", ex);
            }
        }

        public async Task<EventResponse> UpdateEvent(int id, EventRequest @event)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Events/{id}", @event);
                var updatedEvent = await response.Content.ReadFromJsonAsync<EventResponse>();
                return updatedEvent;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating event", ex);
            }
        }
    }
}
