using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyms.API.Models.Entities
{
    public class OpeningHours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public Club Club { get; set; }
    }
}
