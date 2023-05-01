using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NodaTime;
using Gyms.Models.Dtos.Requests;

namespace Gyms.API.Models.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [MaxLength(50)]
        public string Title { get; set; } = "";

        [Required]
        public DayOfWeek Day { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [ForeignKey("Club")]
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }

        [Required]
        [ForeignKey("Coach")]
        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; }   

        [Required]
        public int ParticipantsLimit { get; set; }

        public bool Regular { get; set; } = false;

        public int ParticipantsNumber { get; set; } = 0;

        public bool Cancelled { get; set; } = false;

        public Event() { }

        public Event(EventRequest eventRequest)
        {
            Date = DateOnly.Parse(eventRequest.Date);
            Title = eventRequest.Title;
            Day = eventRequest.Day;
            Time = TimeOnly.Parse(eventRequest.Time);
            Duration = TimeSpan.Parse(eventRequest.Duration);
            ClubId = eventRequest.ClubId;
            CoachId = eventRequest.CoachId;
            ParticipantsLimit = eventRequest.ParticipantsLimit;
            Regular = eventRequest.Regular;
            ParticipantsNumber = eventRequest.ParticipantsNumber;
            Cancelled = eventRequest.Cancelled;
        }
    }
}
