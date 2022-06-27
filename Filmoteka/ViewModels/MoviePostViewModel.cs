using Filmoteka.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Filmoteka.ViewModels
{
    public class MoviePostViewModel
    {
        [Required(ErrorMessage = "Proszę pierwsze wpisać tytuł")]
        [Display(Name = "Tytuł")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Proszę pierwsze podać datę premiery")]
        [Display(Name = "Premiera")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Gatunek")]
        public ICollection<Genre>? Genres { get; set; }
        public ICollection<Actor>? Actors { get; set; }
        [Required(ErrorMessage = "Proszę wybrać obraz filmu")]
        [Display(Name = "Obraz filmu")]
        public IFormFile MovieImage { get; set; }
        
    }
}
