using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class UserInstrumentVm
    {
        public List<ApplicationUser> Users { get; set; }
        public List<UserInstrument> UserInstruments { get; set; }
        public List<UserInstrumentGenre> UserInstrumentGenres { get; set; }
        public SelectList Instruments { get; set; }

        public SelectList Genres { get; set; }
        public string SelectedInstrument { get; set; }
        public string SelectedGenre { get; set; }

        public int SelectedLevelMin { get; set; } = 1;
        public int SelectedLevelMax { get; set; } = 10;
        //public string SearchString { get; set; }

        public IEnumerable<Genre> GenresList { get; set; }
    }
}