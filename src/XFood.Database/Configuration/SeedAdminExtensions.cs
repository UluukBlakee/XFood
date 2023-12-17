using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFood.Data.Models;

namespace XFood.Data.Configuration
{
    public static class SeedAdminExtensions
    {
        public static void InitializeUsersSeedData(this IServiceProvider services)
        {
            var context = services.GetService<XFoodContext>();

            string[] roles = {  "admin", "user" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole<int>, XFoodContext, int>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole<int>(role)).GetAwaiter().GetResult();
                }
            }

            string adminEmail = "admin@admin.com";
            string adminLogin = "admin";
            string adminPassword = "Password123!";

            var user = new User
            {
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                UserName = adminLogin,
                NormalizedUserName = adminLogin.ToUpper(),
                PhoneNumber = string.Empty,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, adminPassword);
                user.PasswordHash = hashed;

                var userStore = new UserStore<User, IdentityRole<int>, XFoodContext, int>(context);

                userStore.CreateAsync(user).GetAwaiter().GetResult();
            }
            context.SaveChangesAsync();
        }

    }
}
