using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MusicDating.Models.Entities 
{
    public class Instrument 
    {
        public int InstrumentId { get; set; }
        
        [Required]
        public string Name { get; set; }


        // Navigation properties
        public ICollection<UserInstrument> UserInstruments { get; set; }
        public ICollection<Agent> Agents { get; set; }

      
    }
}