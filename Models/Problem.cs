using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<Area> Areas { get; set; }

        public ICollection<Mentor> Authors { get; set; }


    }
}
