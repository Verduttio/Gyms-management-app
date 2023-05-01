namespace Gyms.Models.Dtos.Requests
{
    public class ReservationRequest
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
