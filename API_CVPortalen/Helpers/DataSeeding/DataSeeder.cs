using System.Linq;
using API_CVPortalen.Helpers.Programmes;
using API_CVPortalen.Models;
using API_CVPortalen.Models.Programme;
using Microsoft.EntityFrameworkCore;

namespace API_CVPortalen.Helpers.DataSeeding
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder _builder)
        {
            var programmes = SeedProgrammes.DefaultProgrammes().ToArray();
            _builder.Entity<ProgrammeCategory>().HasData(
                SeedProgrammeCategories.DefaultCategories()
            );
            _builder.Entity<Programme>().HasData(
                programmes
            );
            _builder.Entity<User>().HasData(
                SeedUsers.DefaultUsers(programmes)
            );
        }
    }
}