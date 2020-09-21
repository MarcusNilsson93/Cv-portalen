using System;
using API_CVPortalen.Models;
using API_CVPortalen.Models.Programme;

namespace API_CVPortalen.Helpers.Programmes
{
    public static class ProgrammeBuilder
    {
        public static Programme Empty => Default(new Programme());

        public static Programme Default(this Programme programme)
        {
            return new Programme
            {
                Id = 99999,
                Start = DateTime.MinValue.Date,
                End = DateTime.MinValue.Date,
                Name = "Not Assigned",
            };
        }
    }
}