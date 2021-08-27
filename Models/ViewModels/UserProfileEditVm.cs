using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class UserProfileEditVm
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }

        public string Description { get; set; }
      


        
    }
}