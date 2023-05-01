using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;
using Newtonsoft.Json;
using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyms.API.Models.Entities
{
    public class OpeningHours
    {
        [ForeignKey("Club")]
        public int Id { get; set; }

        public TimeOnly MondayFrom { get; set; }

        public TimeOnly MondayTo { get; set; }

        public TimeOnly TuesdayFrom { get; set; }

        public TimeOnly TuesdayTo { get; set; }

        public TimeOnly WednesdayFrom { get; set; }

        public TimeOnly WednesdayTo { get; set; }

        public TimeOnly ThursdayFrom { get; set; }

        public TimeOnly ThursdayTo { get; set; }

        public TimeOnly FridayFrom { get; set; }

        public TimeOnly FridayTo { get; set; }

        public TimeOnly SaturdayFrom { get; set; }

        public TimeOnly SaturdayTo { get; set; }

        public TimeOnly SundayFrom { get; set; }

        public TimeOnly SundayTo { get; set; }

        public virtual Club Club { get; set; }

        public OpeningHours() { }

        public OpeningHours(OpeningHoursRequest openingHoursRequest)
        {
            MondayFrom = TimeOnly.Parse(openingHoursRequest.MondayFrom);
            MondayTo = TimeOnly.Parse(openingHoursRequest.MondayTo);
            TuesdayFrom = TimeOnly.Parse(openingHoursRequest.TuesdayFrom);
            TuesdayTo = TimeOnly.Parse(openingHoursRequest.TuesdayTo);
            WednesdayFrom = TimeOnly.Parse(openingHoursRequest.WednesdayFrom);
            WednesdayTo = TimeOnly.Parse(openingHoursRequest.WednesdayTo);
            ThursdayFrom = TimeOnly.Parse(openingHoursRequest.ThursdayFrom);
            ThursdayTo = TimeOnly.Parse(openingHoursRequest.ThursdayTo);
            FridayFrom = TimeOnly.Parse(openingHoursRequest.FridayFrom);
            FridayTo = TimeOnly.Parse(openingHoursRequest.FridayTo);
            SaturdayFrom = TimeOnly.Parse(openingHoursRequest.SaturdayFrom);
            SaturdayTo = TimeOnly.Parse(openingHoursRequest.SaturdayTo);
            SundayFrom = TimeOnly.Parse(openingHoursRequest.SundayFrom);
            SundayTo = TimeOnly.Parse(openingHoursRequest.SundayTo);
        }

        public OpeningHoursResponse GetOpeningHoursResponseObject()
        {
            OpeningHoursResponse response = new OpeningHoursResponse();

            response.MondayFrom = MondayFrom.ToString();
            response.MondayTo = MondayTo.ToString();
            response.TuesdayFrom = TuesdayFrom.ToString();
            response.TuesdayTo = TuesdayTo.ToString();
            response.WednesdayFrom = WednesdayFrom.ToString();
            response.WednesdayTo = WednesdayTo.ToString();
            response.ThursdayFrom = ThursdayFrom.ToString();
            response.ThursdayTo = ThursdayTo.ToString();
            response.FridayFrom = FridayFrom.ToString();
            response.FridayTo = FridayTo.ToString();
            response.SaturdayFrom = SaturdayFrom.ToString();
            response.SaturdayTo = SaturdayTo.ToString();
            response.SundayFrom = SundayFrom.ToString();
            response.SundayTo = SundayTo.ToString();

            return response;
        }

        public TimeOnly? GetOpeningTime(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return MondayFrom;
                case DayOfWeek.Tuesday:
                    return TuesdayFrom;
                case DayOfWeek.Wednesday:
                    return WednesdayFrom;
                case DayOfWeek.Thursday:
                    return ThursdayFrom;
                case DayOfWeek.Friday:
                    return FridayFrom;
                case DayOfWeek.Saturday:
                    return SaturdayFrom;
                case DayOfWeek.Sunday:
                    return SundayFrom;
                default:
                    return null;
            }
        }

        public TimeOnly? GetClosingTime(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return MondayTo;
                case DayOfWeek.Tuesday:
                    return TuesdayTo;
                case DayOfWeek.Wednesday:
                    return WednesdayTo;
                case DayOfWeek.Thursday:
                    return ThursdayTo;
                case DayOfWeek.Friday:
                    return FridayTo;
                case DayOfWeek.Saturday:
                    return SaturdayTo;
                case DayOfWeek.Sunday:
                    return SundayTo;
                default:
                    return null;
            }
        }
    }
}
