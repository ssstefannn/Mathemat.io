using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mathemat.io.Models
{
    public class ContestSubmissions
    {
        public byte[] SolutionFile { get; set; }

        public string? Solution { get; set; }

        public int Points { get; set; } = 0;

        public Contest Contest { get; set; }

        public Problem Problem { get; set; }

        public Contestant Contestant { get; set; }


    }
}
