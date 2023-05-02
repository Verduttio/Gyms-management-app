using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface ICoachesService
    {
        Task<IEnumerable<CoachResponse>> GetCoaches();
        Task<CoachResponse> GetCoach(int id);
        Task<CoachResponse> AddCoach(CoachRequest coachRequest);
        Task<CoachResponse> DeleteCoach(int id);
    }
}
