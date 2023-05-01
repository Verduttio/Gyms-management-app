namespace Gyms.Models.Dtos.Responses
{
    public class ReservationResponse
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
