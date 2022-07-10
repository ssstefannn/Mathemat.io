using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Mathemat.io.Models
{
    public class Area
    {
        [Key]
        public int AreaID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [StringLength(100)]
        public string Description { get;set; } = String.Empty;

        public ICollection<Problem> Problems { get; set; }

    }
}
