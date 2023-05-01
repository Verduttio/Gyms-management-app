using Gyms.API.Models.Entities;

namespace Gyms.API.Services.Validators
{
    public class EventsValidator
    {
        private readonly ClubsService _clubsService;
        private readonly CoachesService _coachesService;

        public EventsValidator(ClubsService clubsService, CoachesService coachesService)
        {
            _clubsService = clubsService;
            _coachesService = coachesService;
        }

        public async Task<bool> EventInClubOpeningHours(int clubId, DayOfWeek dayOfWeek, TimeOnly time, TimeSpan duration)
        {
            Club club = await _clubsService.GetClubAsync(clubId);
            OpeningHours openingHours = await _clubsService.GetOpeningHoursAsync(clubId);

            TimeOnly? openingTime = openingHours.GetOpeningTime(dayOfWeek);
            TimeOnly? closingTime = openingHours.GetClosingTime(dayOfWeek);
           
            if (openingTime == null || closingTime == null)
            {
                return false;
            }
            else
            {
                if (time < openingTime || time > closingTime || (closingTime - time) < duration)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
