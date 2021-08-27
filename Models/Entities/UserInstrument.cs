using MusicDating.Models.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MusicDating.Models.Entities 
{
public class UserInstrument
{
   // public int UserInstrumentId {get; set;}
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; }
    public int Level { get; set; }
    public ICollection<UserInstrumentGenre> UserInstrumentGenres { get; set; }
}
}