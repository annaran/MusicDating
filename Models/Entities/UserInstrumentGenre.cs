using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicDating.Models.Entities;

public class UserInstrumentGenre
{
    [Key]
    public int UserInstrumentGenreId {get; set;}
    public string ApplicationUserId { get; set; }
    public int InstrumentId { get; set; }
    [ForeignKey("ApplicationUserId,InstrumentId")]
    public UserInstrument UserInstrument { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}