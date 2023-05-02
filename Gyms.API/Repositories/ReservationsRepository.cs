using Gyms.API.Data;
using Gyms.API.Models.Entities;
using Gyms.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gyms.API.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly DataContext _context;

        public ReservationsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return null;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByEventIdAsync(int eventId)
        {
            return await _context.Reservations.Where(r => r.EventId == eventId).ToListAsync();
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return reservation;
        }
    }
}
