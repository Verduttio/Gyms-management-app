using Gyms.API.Models.Entities;

namespace Gyms.API.Services.Validators
{
    public class TimeValidator
    {
        public static bool CheckIfOverlap(TimeOnly start1, TimeOnly end1, TimeOnly start2, TimeOnly end2)
        {
            if (end1 < start2 || end2 < start1)
            {
                return false;
            }

            return true;
        }

        private static bool OpeningTimeIsBeforeClosingTime(TimeOnly start, TimeOnly end)
        {
            return start < end;
        }

        public static bool OpeningHoursCorrect(OpeningHours openingHours)
        {
            return OpeningTimeIsBeforeClosingTime(openingHours.MondayFrom, openingHours.MondayTo) &&
                OpeningTimeIsBeforeClosingTime(openingHours.TuesdayFrom, openingHours.TuesdayTo) &&
                OpeningTimeIsBeforeClosingTime(openingHours.WednesdayFrom, openingHours.WednesdayTo) &&
                OpeningTimeIsBeforeClosingTime(openingHours.ThursdayFrom, openingHours.ThursdayTo) &&
                OpeningTimeIsBeforeClosingTime(openingHours.FridayFrom, openingHours.FridayTo) &&
                OpeningTimeIsBeforeClosingTime(openingHours.SaturdayFrom, openingHours.SaturdayTo) &&
                OpeningTimeIsBeforeClosingTime(openingHours.SundayFrom, openingHours.SundayTo);
        }


    }
}
