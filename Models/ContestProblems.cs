namespace Mathemat.io.Models
{
    public class ContestProblems
    {
        public int ContestID { get; set; }

        public int ProblemID { get; set; }

        public Contest Contest { get; set; }

        public Problem Problem { get; set; }

        
    }
}
