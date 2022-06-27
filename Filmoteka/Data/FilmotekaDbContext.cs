using Filmoteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmoteka.Data
{
    public class FilmotekaDbContext : DbContext
    {
        public FilmotekaDbContext(DbContextOptions<FilmotekaDbContext> options) : base(options)
        {
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
