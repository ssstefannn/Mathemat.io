using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            Finished,
            ResultsOut
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

        [NotMapped]
        public IEnumerable<int>? JudgeIDs { get; set; }

        [NotMapped]
        public IEnumerable<int>? ProblemIDs { get; set; }

        [NotMapped]
        public IEnumerable<int>? ParticipantIDs { get; set; }



    }
}
