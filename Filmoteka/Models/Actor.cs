namespace Filmoteka.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
