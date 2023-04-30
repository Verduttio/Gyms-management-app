using Gyms.API.Models.Entities;

namespace Gyms.API.Repositories.Interfaces
{
    public interface ICoachesRepository
    {
        Task<IEnumerable<Coach>> GetCoachesAsync();
        Task<Coach> GetCoachAsync(int id);
        Task<Coach> AddCoachAsync(Coach coach);
        Task<Coach> UpdateCoachAsync(Coach coach);
        Task<Coach> DeleteCoachAsync(int id);
    }
}
