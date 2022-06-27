using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmoteka.Models
{
    public class Movie
    {   
        public int MovieId { get; set; }
        [Required]
        [Display(Name ="Tytuł")]        
        public string Title { get; set; }
        [Required]
        [Display(Name = "Data premiery")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public Image? Image { get; set; }
        public ICollection<Actor>? Actors { get; set;}
        public ICollection<Genre>? Genres { get; set; }
    }
}
