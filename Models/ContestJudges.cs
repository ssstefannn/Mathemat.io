namespace Mathemat.io.Models
{
    public class ContestJudges
    {
        public int ContestID { get; set; }

        public int MentorID { get; set; }

        public Contest Contest { get; set; }

        public Mentor Judge { get; set; }


    }
}
