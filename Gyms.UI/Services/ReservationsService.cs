using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;
using System.Net.Http;

namespace Gyms.UI.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly HttpClient _httpClient;

        public ReservationsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ReservationResponse> AddReservation(ReservationRequest reservationRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Reservations", reservationRequest);
                var reservation = await response.Content.ReadFromJsonAsync<ReservationResponse?>();
                return reservation;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error adding reservation");
                return null;
            }
        }
        
        public async Task<ReservationResponse> DeleteReservationAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Reservations/{id}");
                var reservation = await response.Content.ReadFromJsonAsync<ReservationResponse?>();
                return reservation;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting reservation");
                return null;
            }
        }

        public async Task<IEnumerable<ReservationResponse>> GetEventReservations(int eventId)
        {
            try
            {
                var reservations = await _httpClient.GetFromJsonAsync<IEnumerable<ReservationResponse>>($"api/Reservations/Event/{eventId}");
                return reservations;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting event's reservations");
                return null;
            }
        }

        public async Task<ReservationResponse> GetReservation(int id)
        {
            try
            {
                var reservation = await _httpClient.GetFromJsonAsync<ReservationResponse>($"api/Reservations/{id}");
                return reservation;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting reservation");
                return null;
            }
        }

        public async Task<IEnumerable<ReservationResponse>> GetReservations()
        {
            try
            {
                var reservations = await _httpClient.GetFromJsonAsync<IEnumerable<ReservationResponse>>("api/Reservations");
                return reservations;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error adding reservations");
                return null;
            }
        }
    }
}
