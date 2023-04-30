using Gyms.API.Models.Requests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gyms.API.Models.Entities
{
    public class Coach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength (50)]
        public string LastName { get; set; }

        public int YearOfBirth { get; set;  }

        public virtual List<Event> Events { get; set; }

        public Coach() { }

        public Coach(CoachRequest coachRequest)
        {
            FirstName = coachRequest.FirstName;
            LastName = coachRequest.LastName;
            YearOfBirth = coachRequest.YearOfBirth;
        }
    }
}
