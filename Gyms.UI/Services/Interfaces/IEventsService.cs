using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface IEventsService
    {
        Task<IEnumerable<EventResponse>> GetEvents();
        Task<EventResponse> GetEvent(int id);
        Task<IEnumerable<EventResponse>> GetCoachEvents(int coachId);
    }
}
