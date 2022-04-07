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
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            CategoryId = 1,
                            Name = "Komedia"
                        },
                        new Category
                        {
                            CategoryId = 2,
                            Name = "Horror"
                        },
                        new Category
                        {
                            CategoryId = 3,
                            Name = "Dokumentalny"
                        },
                        new Category
                        {
                            CategoryId = 4,
                            Name = "Sci-fi"
                        }); ;
                }
                if(!context.Actors.Any())
                {
                    context.Actors.AddRange(
                        new Actor
                        {
                            Name = "Tomasz",
                            Surname = "Adamczyk"
                        },
                        new Actor
                        {
                            Name = "Sigourney",
                            Surname = "Weaver"
                        });
                }
                if(!context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new Movie
                        {
                            Title = "Pieniądze to nie wszystko",
                            ReleaseDate = new DateTime(2001, 1, 5),
                            Categories = new List<Category>()
                            {
                                context.Categories.ElementAt(2)
                            }
                        },
                        new Movie
                        {
                            Title = "Obcy - 8 pasażer Nostromo",
                            ReleaseDate = new DateTime(1979,5,25),
                            Categories = new List<Category>()
                            {
                                context.Categories.ElementAt(1),
                                context.Categories.ElementAt(4)
                            }
                        },
                        new Movie
                        {
                            Title = "Tylko nie mów nikomu",
                            ReleaseDate = new DateTime(2019,5,11),
                            Categories = new List<Category>()
                            {
                                context.Categories.ElementAt(3)
                            }
                        },
                        new Movie
                        {
                            Title = "Prometeusz",
                            ReleaseDate = new DateTime(2012,7,20),
                            Categories = new List<Category>()
                            {
                                context.Categories.ElementAt(4),
                                context.Categories.ElementAt(1)
                            }
                        });
                }
                context.SaveChanges();
            }
        }
    }
}