using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface IClubsService
    {
        Task<IEnumerable<ClubResponse>> GetClubs();
    }
}
