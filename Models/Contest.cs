using System.ComponentModel.DataAnnotations;

namespace Mathemat.io.Models
{
    public class Contest
    {
        public enum DifficultyLevel
        {
            Low,
            Medium,
            High
        }

        public enum StatusLevel
        {
            NotStarted,
            InProgress,
            Finished
        }

        [Key]
        public int ContestID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = String.Empty;

        public DifficultyLevel Difficulty { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        public StatusLevel Status { get; set; }

        public int Duration { get; set; }

        public IEnumerable<ContestJudges>? Judges { get; set; }

        public IEnumerable<Participants>? Participants { get; set; }



        
    }
}
