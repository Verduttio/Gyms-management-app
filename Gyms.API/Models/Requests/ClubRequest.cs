using Gyms.API.Models.Entities;


namespace Gyms.API.Models.DTOs
{
    public class ClubRequest
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public OpeningHoursRequest? OpeningHours { get; set; }
    }
}
