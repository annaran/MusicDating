using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicDating.Models.Entities;

namespace MusicDating.Models.Entities 
{
    public class Genre 
    {
        public int GenreId { get; set; }
        
        [Required]
        public string Name { get; set; }


        // Navigation properties
        public ICollection<EnsembleGenre> EnsembleGenres { get; set; }
        public ICollection<PostGenre> PostGenres { get; set; }
        public ICollection<UserInstrumentGenre> UserInstrumentGenres { get; set; }
    }
}