namespace Mathemat.io.Models
{
    public class Mentorship
    {
        public int MentorID { get; set; }

        public int ContestantID { get; set; }

        public Mentor Mentor { get; set; }

        public Contestant Contestant { get; set; }


    }
}
