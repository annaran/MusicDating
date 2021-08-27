using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class UserProfileVm
    {
        public IEnumerable<ApplicationUser> User { get; set; }
        public IEnumerable<UserInstrument> UserInstruments { get; set; }
        public IEnumerable<Post> UserPosts { get; set; }
        public IEnumerable<Ensemble> UserEnsembles { get; set; }


        //public List<UserInstrumentGenre> UserInstrumentGenres { get; set; }


        public IEnumerable<Genre> GenresList { get; set; }
    }
}