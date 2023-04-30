using Gyms.API.Models.Entities;

namespace Gyms.API.Repositories.Interfaces
{
    public interface IClubsRepository
    {
        Task<IEnumerable<Club>> GetClubsAsync();
        Task<Club> GetClubAsync(int id);
        Task<Club> AddClubAsync(Club club);
        Task<Club> UpdateClubAsync(Club club);
        Task<Club> DeleteClubAsync(int id);
    }
}
