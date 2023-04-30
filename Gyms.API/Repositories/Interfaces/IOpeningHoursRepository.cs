using Gyms.API.Models.Entities;

namespace Gyms.API.Repositories.Interfaces
{
    public interface IOpeningHoursRepository
    {
        Task<OpeningHours> GetOpeningHoursAsync(int id);
        Task<OpeningHours> UpdateOpeningHoursAsync(OpeningHours openingHours);
    }
}
