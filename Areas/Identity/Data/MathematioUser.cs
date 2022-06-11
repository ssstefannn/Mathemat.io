using Microsoft.AspNetCore.Identity;

namespace Mathematio.Areas.Identity.Data
{
    public class MathematioUser : IdentityUser
    {
        public int LinkId { get; set; }
    }
}
