using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface ICoachesService
    {
        Task<IEnumerable<CoachResponse>> GetCoaches();
        Task<CoachResponse> GetCoach(int id);
    }
}
