using System.ComponentModel.DataAnnotations;

namespace Mathemat.io.Models
{
    public class Problem
    {
        public enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard
        }

        [Key]
        public int ProblemId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public DifficultyLevel Difficulty { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        public IEnumerable<ProblemAreas>? Areas { get; set; }

        public IEnumerable<ProblemAuthors>? Authors { get; set; }


    }
}
