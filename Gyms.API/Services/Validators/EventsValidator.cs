using Gyms.API.Models.Entities;

namespace Gyms.API.Services.Validators
{
    public class EventsValidator
    {
        private readonly ClubsService _clubsService;

        public EventsValidator(ClubsService clubsService)
        {
            _clubsService = clubsService;
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

        public bool CoachFree(IEnumerable<Event> coachEvents, DateOnly date, TimeOnly time, TimeSpan duration)
        {
            foreach (Event coachEvent in coachEvents)
            {
                if (coachEvent.Date == date)
                {
                    var coachEventStartTime = coachEvent.Time;
                    var coachEventEndTime = coachEvent.Time.Add(coachEvent.Duration);

                    var newEventStartTime = time;
                    var newEventEndTime = time.Add(duration);

                    if(TimeValidator.CheckIfOverlap(coachEventStartTime, coachEventEndTime, newEventStartTime, newEventEndTime)) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
