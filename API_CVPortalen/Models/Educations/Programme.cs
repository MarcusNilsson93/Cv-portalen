using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_CVPortalen.Models.Programme
{
    public class Programme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; } = 99999;
        public virtual ProgrammeCategory Category { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<User> Students { get; set; }
    }
}