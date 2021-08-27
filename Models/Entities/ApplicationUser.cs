using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using MusicDating.Models.Entities;


public class ApplicationUser : IdentityUser
{
    public DateTime DateCreated { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Picture { get; set; }
    public string Postcode { get; set; }
    public string City { get; set; }

    public string Description { get; set; }
    public DateTime Birthday { get; set; }
    public bool ProfileStatus { get; set; }

    public bool Newsletter { get; set; }



    public ICollection<UserInstrument> UserInstruments { get; set; }
    public ICollection<Post> Posts { get; set; }
}
