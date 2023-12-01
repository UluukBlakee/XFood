using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using XFood.Data.Models;

namespace XFood.Database.Models
{
    public class XFoodContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pizzeria> Pizzerias { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<Criterion> Criteria { get; set; }
        public DbSet<CategoryFactor> CategoryFactors { get; set; }
        public DbSet<CriticalFactor> CriticalFactors { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<OpportunitySchedule> OpportunitySchedules { get; set; }
        public XFoodContext(DbContextOptions<XFoodContext> options) : base(options) { }
    }
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<XFoodContext>
    //{
    //    public XFoodContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build();
    //        var builder = new DbContextOptionsBuilder<XFoodContext>();
    //        var connectionString = configuration.GetConnectionString("DatabaseConnection");
    //        builder.UseSqlServer(connectionString);
    //        return new XFoodContext(builder.Options);
    //    }
    //}
}
