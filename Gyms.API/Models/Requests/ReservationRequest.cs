using Gyms.API.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gyms.API.Models.Requests
{
    public class ReservationRequest
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
