using Gyms.API.Models.Entities;
using Gyms.Models.Dtos.Requests;
using Gyms.API.Repositories.Interfaces;
using Gyms.API.Services.Validators;

namespace Gyms.API.Services
{
    public class ReservationsService
    {
        private readonly IReservationsRepository _reservationsRepository;
        private readonly ReservationsValidator _reservationsValidator;

        public ReservationsService(IReservationsRepository reservationsRepository, ReservationsValidator reservationsValidator)
        {
            _reservationsRepository = reservationsRepository;
            _reservationsValidator = reservationsValidator;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservationsRepository.GetReservationsAsync();
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await _reservationsRepository.GetReservationAsync(id);
        }

        public async Task<Reservation?> AddReservationAsync(ReservationRequest reservationRequest)
        {
            Reservation reservation = new Reservation(reservationRequest);
            if(await _reservationsValidator.IsFreePlace(reservation.EventId))
            {
                await _reservationsValidator.IncrementReservationsNumber(reservation.EventId);
                return await _reservationsRepository.AddReservationAsync(reservation);
            } else
            {
                return null;
            }
            
        }

        public async Task<Reservation?> UpdateReservationAsync(int id, ReservationRequest reservationRequest)
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
            Reservation reservation = await GetReservationAsync(id);
            await _reservationsValidator.DecrementReservationsNumber(reservation.EventId);
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
