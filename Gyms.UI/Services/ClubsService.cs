using Gyms.Models.Dtos.Requests;
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
                System.Diagnostics.Debug.WriteLine("Error getting clubs");
                return null;
            }
        }

        public async Task<ClubResponse> GetClub(int id)
        {
            try
            {
                var club = await _httpClient.GetFromJsonAsync<ClubResponse>($"api/Clubs/{id}");
                return club;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting club");
                return null;
            }
        }

        public async Task<OpeningHoursResponse> GetClubOpeningHours(int clubId)
        {
            try
            {
                var openingHours = await _httpClient.GetFromJsonAsync<OpeningHoursResponse>($"api/Clubs/{clubId}/OpeningHours");
                return openingHours;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting club's opening hours");
                return null;
            }
        }

        public async Task<ClubResponse?> AddClub(ClubRequest clubRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Clubs", clubRequest);
                var club = await response.Content.ReadFromJsonAsync<ClubResponse?>();
                return club;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error adding club");
                return null;
            }
        }

        public async Task<ClubResponse> DeleteClub(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Clubs/{id}");
                var club = await response.Content.ReadFromJsonAsync<ClubResponse?>();
                return club;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting club");
                return null;
            }
        }
    }
}
