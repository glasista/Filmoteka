using Filmoteka.Models;

namespace Filmoteka.ViewModels
{
    public class MovieEditViewModel : MoviePostViewModel
    {
        public int MovieId { get; set; }
        public string ImageName { get; set; }

        public MovieEditViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            Genres = movie.Genres;
        }
    }
}
