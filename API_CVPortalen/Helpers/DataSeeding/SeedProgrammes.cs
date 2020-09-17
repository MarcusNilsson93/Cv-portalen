using System;
using System.Collections;
using System.Collections.Generic;
using API_CVPortalen.Helpers.Programmes;
using API_CVPortalen.Models;
using API_CVPortalen.Models.Programme;

namespace API_CVPortalen.Helpers.DataSeeding
{
    public class SeedProgrammes
    {
        public static IEnumerable<Programme> DefaultProgrammes()
        {
            return new[]
            {
                ProgrammeBuilder.Empty,
                new Programme{Id=1, Start = DateTime.Parse("2000-01-02"), End = DateTime.Parse("2002-01-02"), Name = "Webb00", CategoryId = 1},
                new Programme{Id=2, Start = DateTime.Parse("2000-01-02"), End = DateTime.Parse("2002-01-02"), Name = "DotNet00", CategoryId=2},
                new Programme{Id=3, Start = DateTime.Parse("2000-01-02"), End = DateTime.Parse("2002-01-02"), Name = "Java00", CategoryId = 3},
            };
        }
    }
    public class SeedProgrammeCategories
    {
        public static IEnumerable<ProgrammeCategory> DefaultCategories()
        {
            return new[]
            {
                new ProgrammeCategory{Id = 1, Name = "Webbutvecklare"},
                new ProgrammeCategory{Id= 2, Name= ".NetUtvecklare"},
                new ProgrammeCategory{Id = 3,Name = "JavaUtvecklare"},
                new ProgrammeCategory{Id = 99999, Name = "Not Assigned"}, 
            };
        }
    }
}