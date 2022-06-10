using Mathemat.io.Data;
using Mathematio.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mathematio.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<MathematioUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            MathematioUser user = await UserManager.FindByEmailAsync("admin@mathematio.com");
            if (user == null)
            {
                var User = new MathematioUser();
                User.Email = "admin@mathematio.com";
                User.UserName = "admin@mathematio.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = await UserManager.AddToRoleAsync(User, "Admin");
                }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MathematioContext(
                serviceProvider.GetRequiredService<DbContextOptions<MathematioContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
            }
        }
    }
}
