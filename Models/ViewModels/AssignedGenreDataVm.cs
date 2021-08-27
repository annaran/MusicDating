using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDating.Models.ViewModels
{
    public class AssignedGenreDataVm
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}