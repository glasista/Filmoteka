using Filmoteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmoteka.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FilmotekaDbContext(serviceProvider.GetRequiredService<DbContextOptions<FilmotekaDbContext>>()))
            {
                if (context.Genres.Count() <1)
                {
                    context.Genres.AddRange(
                        new Genre
                        {
                            
                            Name = "Komedia"
                        },
                        new Genre
                        {
                           
                            Name = "Horror"
                        },
                        new Genre
                        {
                            
                            Name = "Dokumentalny"
                        },
                        new Genre
                        {
                           
                            Name = "Sci-fi"
                        }); ;
                }
                context.SaveChanges();
                if(!context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new Movie
                        {
                            Title = "Pieniądze to nie wszystko",
                            ReleaseDate = new DateTime(2001, 1, 5),
                        },
                        new Movie
                        {
                            Title = "Obcy - 8 pasażer Nostromo",
                            ReleaseDate = new DateTime(1979,5,25),
                        },
                        new Movie
                        {
                            Title = "Tylko nie mów nikomu",
                            ReleaseDate = new DateTime(2019,5,11),
                        },
                        new Movie
                        {
                            Title = "Prometeusz",
                            ReleaseDate = new DateTime(2012,7,20),
                        });
                }
                context.SaveChanges();
            }
        }
    }
}