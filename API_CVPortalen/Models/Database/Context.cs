using API_CVPortalen.Helpers.DataSeeding;
using Microsoft.EntityFrameworkCore;

namespace API_CVPortalen.Models.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DataSeeder.Seed(builder);
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Programme.Programme> Programmes { get; set; }
        public DbSet<Programme.ProgrammeCategory> ProgrammeCategories { get; set; }
    }
}