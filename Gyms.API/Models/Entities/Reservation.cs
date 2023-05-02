using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyms.API.Models.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        public Reservation() { }

        public Reservation(ReservationRequest reservationRequest)
        {
            EventId = reservationRequest.EventId;
            Name = reservationRequest.Name;
            Surname = reservationRequest.Surname;
        }

        public static ReservationResponse MakeReservationResponse(Reservation reservation)
        {
            if(reservation == null)
            {
                return null;
            }

            ReservationResponse reservationResponse = new ReservationResponse();
            reservationResponse.Id = reservation.Id;
            reservationResponse.EventId = reservation.EventId;
            reservationResponse.Name = reservation.Name;
            reservationResponse.Surname = reservation.Surname;
            return reservationResponse;
        }
    }
}
