using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mathemat.io.Models
{
    public class ContestSubmissions
    {
        public int ContestID { get; set; }

        public int ProblemID { get; set; }

        public int ContestantID { get; set; }

        [NotMapped]
        public IFormFile? SolutionFile { get; set; }

        public string? Solution { get; set; }

        public int Points { get; set; } = 0;

        public Contest? Contest { get; set; }

        public Problem? Problem { get; set; }

        public Contestant? Contestant { get; set; }


    }
}
