using System;
using System.Collections;
using System.Collections.Generic;
using API_CVPortalen.Helpers.Programmes;
using API_CVPortalen.Models;

namespace API_CVPortalen.Helpers.DataSeeding
{
    public class SeedProgrammes
    {
        public static IEnumerable<Programme> DefaultProgrammes()
        {
            return new[]
            {
                ProgrammeBuilder.Empty,
                new Programme{Id=1, Start = DateTime.Parse("2000-01-02"), End = DateTime.Parse("2002-01-02"), Name = "Webbutveckling"},
                new Programme{Id=2, Start = DateTime.Parse("2000-01-02"), End = DateTime.Parse("2002-01-02"), Name = "DotNet"},
                new Programme{Id=3, Start = DateTime.Parse("2000-01-02"), End = DateTime.Parse("2002-01-02"), Name = "JavaUtvecklare"},
            };
        }
    }
}