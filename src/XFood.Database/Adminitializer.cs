using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFood.Data.Models;

namespace XFood.Data
{
    public class Adminitializer
    {

        public static async Task SeedAdminUser(RoleManager<IdentityRole<int>> roleManager, UserManager<User> userManager)
        {
            string adminEmail = "admin@admin.admin";
            string adminPassword = "Password123!";
            string adminName = "admin";
            var roles = new[] { "admin", "user", };
            foreach (var role in roles)
            {
                if (await roleManager.FindByNameAsync(role) is null)
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
            }
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                User admin = new() { Email = adminEmail, UserName = adminName, FirstName = adminName, LastName = adminName };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
                if (await roleManager.FindByNameAsync("Applicant") == null)
                    await roleManager.CreateAsync(new IdentityRole<int>("Applicant"));
                if (await roleManager.FindByNameAsync("Employer") == null)
                    await roleManager.CreateAsync(new IdentityRole<int>("Employer"));
            }
        }
    }
}

