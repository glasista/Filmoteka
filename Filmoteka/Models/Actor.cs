using System.ComponentModel.DataAnnotations;

namespace Filmoteka.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Required]
        [Display(Name="Imię")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Nazwisko")]
        public string Surname { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
