using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;

namespace Gyms.UI.Services
{
    public class ClubsService : IClubsService
    {
        private readonly HttpClient _httpClient;

        public ClubsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ClubResponse>> GetClubs()
        {
            try
            {
                var clubs = await _httpClient.GetFromJsonAsync<IEnumerable<ClubResponse>>("api/Clubs");
                return clubs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
