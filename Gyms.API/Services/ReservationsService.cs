using Gyms.API.Models.Entities;
using Gyms.API.Models.Requests;
using Gyms.API.Repositories.Interfaces;

namespace Gyms.API.Services
{
    public class ReservationsService
    {
        private readonly IReservationsRepository _reservationsRepository;

        public ReservationsService(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservationsRepository.GetReservationsAsync();
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await _reservationsRepository.GetReservationAsync(id);
        }

        public async Task<Reservation> AddReservationAsync(ReservationRequest reservationRequest)
        {
            Reservation reservation = new Reservation(reservationRequest);
            return await _reservationsRepository.AddReservationAsync(reservation);
        }

        public async Task<Reservation> UpdateReservationAsync(int id, ReservationRequest reservationRequest)
        {
            Reservation reservation = await GetReservationAsync(id);
            if(reservation == null)
            {
                return null;
            }

            SetReservation(reservation, reservationRequest);
            
            return await _reservationsRepository.UpdateReservationAsync(reservation);
        }

        public async Task<Reservation> DeleteReservationAsync(int id)
        {
            return await _reservationsRepository.DeleteReservationAsync(id);
        }

        private void SetReservation(Reservation reservation, ReservationRequest reservationRequest)
        {
            reservation.EventId = reservationRequest.EventId;
            reservation.Name = reservationRequest.Name;
            reservation.Surname = reservationRequest.Surname;
        }



    }
}
