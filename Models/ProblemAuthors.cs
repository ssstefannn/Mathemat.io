namespace Mathemat.io.Models
{
    public class ProblemAuthors
    {
        public int ProblemID { get; set; }

        public int MentorID { get; set; }

        public Problem Problem { get; set; }

        public Mentor Author { get; set; }


    }
}
