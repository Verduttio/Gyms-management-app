using Gyms.API.Models.Entities;
using Gyms.Models.Dtos.Requests;
using Gyms.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gyms.Models.Dtos.Responses;

namespace Gyms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationsService _reservationsService;

        public ReservationsController(ReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<IEnumerable<ReservationResponse>> GetReservations()
        {
            IEnumerable<Reservation> reservations = await _reservationsService.GetReservationsAsync();
            IEnumerable<ReservationResponse> reservationResponses = reservations.Select(r => Reservation.MakeReservationResponse(r)).ToList();

            return reservationResponses;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ReservationResponse> GetReservation(int id)
        {
            Reservation reservation = await _reservationsService.GetReservationAsync(id);
            return Reservation.MakeReservationResponse(reservation);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<ReservationResponse> PutReservation(int id, ReservationRequest reservationRequest)
        {
            Reservation reservation = await _reservationsService.UpdateReservationAsync(id, reservationRequest);
            return Reservation.MakeReservationResponse(reservation);
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ReservationResponse> PostReservation(ReservationRequest reservationRequest)
        {
            Reservation reservation = await _reservationsService.AddReservationAsync(reservationRequest);
            return Reservation.MakeReservationResponse(reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ReservationResponse> DeleteReservation(int id)
        {
            Reservation reservation = await _reservationsService.DeleteReservationAsync(id);
            return Reservation.MakeReservationResponse(reservation);
        }

        // GET: api/Reservations/Event/5
        [HttpGet("Event/{eventId}")]
        public async Task<IEnumerable<ReservationResponse>> GetReservationsByEventId(int eventId)
        {
            IEnumerable<Reservation> reservations = await _reservationsService.GetReservationsByEventIdAsync(eventId);
            IEnumerable<ReservationResponse> reservationResponses = reservations.Select(r => Reservation.MakeReservationResponse(r)).ToList();
            return reservationResponses;
        }
    }
}
