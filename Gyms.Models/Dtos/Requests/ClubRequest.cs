namespace Gyms.Models.Dtos.Requests
{
    public class ClubRequest
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public OpeningHoursRequest OpeningHours { get; set; } = new OpeningHoursRequest();
    }
}
