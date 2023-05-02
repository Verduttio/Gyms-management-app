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
    }
}
