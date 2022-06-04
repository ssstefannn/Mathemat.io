namespace Mathemat.io.Models
{
    public class Participants
    {
        public int ContestID { get; set; }

        public int ContestantID { get; set; }

        public Contest Contest { get; set; }

        public Contestant Contestant { get; set; }


    }
}
