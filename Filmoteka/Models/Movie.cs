using System.ComponentModel.DataAnnotations;

namespace Filmoteka.Models
{
    public class Movie
    {   
        public int MovieId { get; set; }
        [Display(Name ="Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Data premiery")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public ICollection<Actor> Actors { get; set;}
        public ICollection<Category> Categories { get; set; }
    }
}
