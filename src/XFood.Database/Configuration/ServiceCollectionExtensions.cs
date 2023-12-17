using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XFood.Data.Models;

namespace XFood.Data.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<XFoodContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole<int>>()
               .AddEntityFrameworkStores<XFoodContext>()
               .AddDefaultUI()
            .AddDefaultTokenProviders(); ;
            return services;
        }
    }
}