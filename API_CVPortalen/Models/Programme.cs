using System;

namespace API_CVPortalen.Models
{
    public class Programme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}