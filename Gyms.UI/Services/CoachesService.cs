using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;

namespace Gyms.UI.Services
{
    public class CoachesService : ICoachesService
    {
        private readonly HttpClient _httpClient;

        public CoachesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CoachResponse> GetCoach(int id)
        {
            try
            {
                var coach = await _httpClient.GetFromJsonAsync<CoachResponse>($"api/Coaches/{id}");
                return coach;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting coach", ex);
            }
        }

        public async Task<IEnumerable<CoachResponse>> GetCoaches()
        {
            try
            {
                var coaches = await _httpClient.GetFromJsonAsync<IEnumerable<CoachResponse>>("api/Coaches");
                return coaches;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting coaches", ex);
            }
        }
    }
}
