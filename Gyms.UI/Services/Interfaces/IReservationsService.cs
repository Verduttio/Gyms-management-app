using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface IReservationsService
    {
        Task<IEnumerable<ReservationResponse>> GetReservations();
        Task<ReservationResponse> GetReservation(int id);
        Task<ReservationResponse> AddReservation(ReservationRequest reservationRequest);
        Task<ReservationResponse> DeleteReservationAsync(int id);
        Task<IEnumerable<ReservationResponse>> GetEventReservations(int eventId);
    }
}
