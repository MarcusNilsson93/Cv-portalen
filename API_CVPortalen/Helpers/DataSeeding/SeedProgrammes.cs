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
                new Programme{Id=1, Start = DateTime.Parse("2000-01-02").Date, End = DateTime.Parse("2002-01-02").Date, Name = "Webb00", CategoryId = 1},
                new Programme{Id=2, Start = DateTime.Parse("2000-01-02").Date, End = DateTime.Parse("2002-01-02").Date, Name = "DotNet00", CategoryId=2},
                new Programme{Id=3, Start = DateTime.Parse("2000-01-02").Date, End = DateTime.Parse("2002-01-02").Date, Name = "Java00", CategoryId = 3},
            };
        }
    }
    public class SeedProgrammeCategories
    {
        public static IEnumerable<ProgrammeCategory> DefaultCategories()
        {
            return new[]
            {
                new ProgrammeCategory{ProgrammeCategoryId  = 1, Name = "Webbutvecklare"},
                new ProgrammeCategory{ProgrammeCategoryId = 2, Name= ".NetUtvecklare"},
                new ProgrammeCategory{ProgrammeCategoryId  = 3,Name = "JavaUtvecklare"},
                new ProgrammeCategory{ProgrammeCategoryId  = 99999, Name = "Not Assigned"}, 
            };
        }
    }
}