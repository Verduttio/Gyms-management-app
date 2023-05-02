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
                var reservation = await response.Content.ReadFromJsonAsync<ReservationResponse>();
                return reservation;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding reservation", ex);
            }
        }
        
        public async Task<ReservationResponse> DeleteReservationAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Reservations/{id}");
                var reservation = await response.Content.ReadFromJsonAsync<ReservationResponse>();
                return reservation;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting reservation", ex);
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
                throw new Exception("Error getting event's reservations", ex);
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
                throw new Exception("Error getting reservation", ex);
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
                throw new Exception("Error getting reservations", ex);
            }
        }
    }
}
