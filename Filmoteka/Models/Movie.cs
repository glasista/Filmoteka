namespace Filmoteka.Models
{
    public class Movie
    {   
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Actor> Actors { get; set;}
        public ICollection<Category> Categories { get; set; }
    }
}
