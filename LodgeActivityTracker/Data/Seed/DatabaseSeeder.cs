using LodgeActivityTracker.Data;
using Microsoft.AspNetCore.Identity;

namespace LodgeActivityTracker.Data.Seed
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // ✅ 1. Create Roles
            string[] roles = { "Admin", "User", "Guest" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // ✅ 2. Create Admin User
            string adminEmail = "admin@lerato.com";
            string adminPassword = "Lerato@91";

            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            // ✅ 3. Create Guest User
            string guestEmail = "guest@lodge.com";
            string guestPassword = "Guest123!";

            var guest = await userManager.FindByEmailAsync(guestEmail);
            if (guest == null)
            {
                guest = new IdentityUser { UserName = guestEmail, Email = guestEmail };
                var result = await userManager.CreateAsync(guest, guestPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(guest, "Guest");
                }
            }

            // ✅ Optional: You can also create a default regular User here if needed
            string userEmail = "user@lodge.com";
            string userPassword = "User123!";

            var user = await userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                user = new IdentityUser { UserName = userEmail, Email = userEmail };
                var result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
