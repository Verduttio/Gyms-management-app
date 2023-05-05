using Gyms.Models.Dtos.Responses;

namespace Gyms.Models.Dtos.Requests
{
    public class EventRequest
    {
        public string Date { get; set; }

        public string Title { get; set; } = "";

        //public DayOfWeek Day { get; set; }

        public string Time { get; set; }

        public string Duration { get; set; }

        public int ClubId { get; set; }

        public int CoachId { get; set; }

        public int ParticipantsLimit { get; set; }

        public bool Regular { get; set; } = false;

        public int ParticipantsNumber { get; set; } = 0;

        public bool Cancelled { get; set; } = false;

        public EventRequest() { }

        public EventRequest(EventResponse eventResponse) {
            Date = eventResponse.Date;
            Title = eventResponse.Title;
            Time = eventResponse.Time;
            Duration = eventResponse.Duration;
            ClubId = eventResponse.ClubId;
            CoachId = eventResponse.CoachId;
            ParticipantsLimit = eventResponse.ParticipantsLimit;
            Regular = eventResponse.Regular;
            ParticipantsNumber = eventResponse.ParticipantsNumber;
            Cancelled = eventResponse.Cancelled;
        }
    }
}
