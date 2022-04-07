using Filmoteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmoteka.Data
{
    public class FilmotekaDbContext : DbContext
    {
        public FilmotekaDbContext(DbContextOptions<FilmotekaDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
