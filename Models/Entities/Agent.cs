using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MusicDating.Models.Entities {
    public class Agent {
        public int AgentId { get; set; }
        
        
        [RegularExpression(@"^\d{1,10}$", ErrorMessage="Level must be between 1-10")]
        [Required]
        public int Level { get; set; }

        public string Postcode { get; set; }


        // Navigation properties
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}