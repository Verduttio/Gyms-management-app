using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Gyms.API.Data;
using Gyms.Models.Dtos.Requests;

namespace Gyms.API.Models.Entities
{
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Address { get; set; }

        public OpeningHours OpeningHours { get; set; }

        public List<Event> Events { get; set; }

        public Club() { }

        public Club(ClubRequest clubRequest)
        {
            Name = clubRequest.Name;
            Address = clubRequest.Address;
            OpeningHours = new OpeningHours(clubRequest.OpeningHours);
        }
    }
}
