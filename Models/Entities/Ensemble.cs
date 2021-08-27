using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicDating.Models.Entities;

namespace MusicDating.Models.Entities 
{
    public class Ensemble 
    {
        public int EnsembleId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }
        public string Description { get; set; }
        public string Homepage { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }

        public string ApplicationUserId { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int PracticeFrequencyId { get; set; }

        [Display(Name = "Practice Frequency")]
        public PracticeFrequency PracticeFrequency { get; set; }

        [Display(Name = "Playing regularly")]
        public bool PlayRegular { get; set; }

        [Display(Name = "Playing project based")]
        public bool PlayProject { get; set; }



        // Navigation properties
        public ICollection<EnsembleGenre> EnsembleGenres { get; set; }
    }
}