using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicDating.Models.Entities;

namespace MusicDating.Models.Entities 
{
    public class Post 
    {
        public int PostId { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Level {get; set;}
        
        
        
        // Navigation properties
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        

        public string ApplicationUserId { get; set; }
        public  ApplicationUser ApplicationUser { get; set; }

        public int EnsembleId { get; set; }
        public Ensemble Ensemble { get; set; }

        public ICollection<PostGenre> PostGenres { get; set; }

      
    }
}