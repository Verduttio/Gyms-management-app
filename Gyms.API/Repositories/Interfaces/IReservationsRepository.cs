using Gyms.API.Models.Entities;

namespace Gyms.API.Repositories.Interfaces
{
    public interface IReservationsRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationAsync(int id);
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task<Reservation> DeleteReservationAsync(int id);
    }
}
