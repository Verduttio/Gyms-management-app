using Gyms.API.Models.Entities;
using Gyms.Models.Dtos.Requests;
using Gyms.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _reservationsService.GetReservationsAsync();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<Reservation> GetReservation(int id)
        {
            return await _reservationsService.GetReservationAsync(id);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<Reservation> PutReservation(int id, ReservationRequest reservationRequest)
        {
            return await _reservationsService.UpdateReservationAsync(id, reservationRequest);
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<Reservation> PostReservation(ReservationRequest reservationRequest)
        {
            return await _reservationsService.AddReservationAsync(reservationRequest);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<Reservation> DeleteReservation(int id)
        {
            return await _reservationsService.DeleteReservationAsync(id);
        }
    }
}
