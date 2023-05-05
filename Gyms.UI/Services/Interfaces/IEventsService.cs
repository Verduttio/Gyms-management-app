using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface IEventsService
    {
        Task<IEnumerable<EventResponse>> GetEvents();
        Task<EventResponse> GetEvent(int id);
        Task<EventResponse> AddEvent(EventRequest eventRequest);
        Task<IEnumerable<EventResponse>> GetCoachEvents(int coachId);
        Task<IEnumerable<EventResponse>> GetClubEvents(int clubId);
        Task<EventResponse> DeleteEvent(int id);
        Task<EventResponse> UpdateEvent(int id, EventRequest eventRequest);
    }
}
