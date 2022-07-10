using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mathemat.io.Models
{
    public class Mentor
    {
        [Key]
        public int MentorID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(30)]
        public string Country { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(100)]
        public string? Profession { get; set; }

        public int MentorPoints { get; set; } = 0;


        public ICollection<Contest> ContestsOrganized { get; set; }

        public ICollection<Contest> ContestsParticipated { get; set; }

        public ICollection<Contestant> Contestants { get; set; }

    }
}
