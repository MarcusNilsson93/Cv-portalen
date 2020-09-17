using System.Collections.Generic;
using System.Linq;
using API_CVPortalen.Models.Programme;

namespace API_CVPortalen.Helpers.Programmes
{
    public static class ProgrammeResponse
    {
        public static object Short(this IEnumerable<Programme> programmes)
        {
            return programmes?.Select(x => x.Short());
        }
        public static object Short(this Programme programme)
        {
            return new { programme.Id, programme.Name, programme.Category, programme.Start, programme.End, Enrolled = programme.Students.Count};
        }
    }
}