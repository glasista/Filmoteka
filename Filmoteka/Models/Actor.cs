using System.ComponentModel.DataAnnotations;

namespace Filmoteka.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Display(Name="Imię")]
        public string Name { get; set; }
        [Display(Name ="Nazwisko")]
        public string Surname { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
