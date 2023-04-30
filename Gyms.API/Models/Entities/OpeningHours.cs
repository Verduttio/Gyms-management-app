using Gyms.API.Models.DTOs;
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
    }
}
