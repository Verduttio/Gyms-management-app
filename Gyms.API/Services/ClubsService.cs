using Gyms.Models.Dtos.Requests;
using Gyms.API.Models.Entities;
using Gyms.API.Repositories.Interfaces;

namespace Gyms.API.Services
{
    public class ClubsService
    {
        private readonly IClubsRepository _clubsRepository;
        private readonly IOpeningHoursRepository _openingHoursRepository;

        public ClubsService(IClubsRepository clubsRepository, IOpeningHoursRepository openingHoursRepository)
        {
            _clubsRepository = clubsRepository;
            _openingHoursRepository = openingHoursRepository;
        }

        public async Task<IEnumerable<Club>> GetClubsAsync()
        {
            return await _clubsRepository.GetClubsAsync();
        }

        public async Task<Club> GetClubAsync(int id)
        {
            return await _clubsRepository.GetClubAsync(id);
        }

        public async Task<Club> AddClubAsync(ClubRequest clubRequest)
        {
            Club club = new Club(clubRequest);
            return await _clubsRepository.AddClubAsync(club);
        }

        public async Task<Club> UpdateClubAsync(int id, ClubRequest clubRequest)
        {
            Club club = await GetClubAsync(id);
            if(club == null)
            {
                return null;
            }

            club.Name = clubRequest.Name;
            club.Address = clubRequest.Address;
            OpeningHours openingHours = await GetOpeningHoursAsync(club.Id);
            OpeningHoursSetter(openingHours, clubRequest.OpeningHours);

            await _openingHoursRepository.UpdateOpeningHoursAsync(openingHours);
            return await _clubsRepository.UpdateClubAsync(club);
        }

        public async Task<OpeningHours> GetOpeningHoursAsync(int clubId)
        {
            return await _openingHoursRepository.GetOpeningHoursAsync(clubId);
        }

        public async Task<Club> DeleteClubAsync(int id)
        {
            return await _clubsRepository.DeleteClubAsync(id);
        }

        private void OpeningHoursSetter(OpeningHours openingHours, OpeningHoursRequest openingHoursRequest)
        {
            openingHours.MondayFrom = TimeOnly.Parse(openingHoursRequest.MondayFrom);
            openingHours.MondayTo = TimeOnly.Parse(openingHoursRequest.MondayTo);

            openingHours.TuesdayFrom = TimeOnly.Parse(openingHoursRequest.TuesdayFrom);
            openingHours.TuesdayTo = TimeOnly.Parse(openingHoursRequest.TuesdayTo);

            openingHours.WednesdayFrom = TimeOnly.Parse(openingHoursRequest.WednesdayFrom);
            openingHours.WednesdayTo = TimeOnly.Parse(openingHoursRequest.WednesdayTo);

            openingHours.ThursdayFrom = TimeOnly.Parse(openingHoursRequest.ThursdayFrom);
            openingHours.ThursdayTo = TimeOnly.Parse(openingHoursRequest.ThursdayTo);

            openingHours.FridayFrom = TimeOnly.Parse(openingHoursRequest.FridayFrom);
            openingHours.FridayTo = TimeOnly.Parse(openingHoursRequest.FridayTo);

            openingHours.SaturdayFrom = TimeOnly.Parse(openingHoursRequest.SaturdayFrom);
            openingHours.SaturdayTo = TimeOnly.Parse(openingHoursRequest.SaturdayTo);

            openingHours.SundayFrom = TimeOnly.Parse(openingHoursRequest.SundayFrom);
            openingHours.SundayTo = TimeOnly.Parse(openingHoursRequest.SundayTo);


        }

    }
}
