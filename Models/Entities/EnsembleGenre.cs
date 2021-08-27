using MusicDating.Models.Entities;

public class EnsembleGenre
{
    //public int EnsembleGenreId {get; set;}
    public int EnsembleId { get; set; }
    public Ensemble Ensemble { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}