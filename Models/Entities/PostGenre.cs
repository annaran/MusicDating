using MusicDating.Models.Entities;

public class PostGenre
{
    //public int PostGenreId {get; set;}
    public int PostId { get; set; }
    public Post Post { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}