using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_CVPortalen.Models.Programme
{
    public class ProgrammeCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        [JsonIgnore]
        public virtual ICollection<Programme> Programmes { get; set; }
    }
}