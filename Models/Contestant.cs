using System.ComponentModel.DataAnnotations;

namespace Mathemat.io.Models
{
    public class Contestant
    {
        [Key]
        public int ContestantID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate {get; set; }

        [StringLength(100)]
        public string? School { get; set; }

        public int ContestantPoints { get; set; } = 0;

        public ICollection<Contest> Contests { get; set; }

        public ICollection<Mentor> Mentors { get; set; }


    }
}
