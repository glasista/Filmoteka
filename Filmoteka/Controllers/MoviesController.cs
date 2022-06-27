#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filmoteka.Data;
using Filmoteka.Models;
using Filmoteka.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace Filmoteka.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FilmotekaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MoviesController(FilmotekaDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MoviePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueImageName = UploadedFile(model);
                Image newImage = new Image()
                {
                    Name = uniqueImageName,
                    IsApplied = true,
                };
                
                _context.Images.Add(newImage);

                Movie newMovie = new Movie()
                {
                    Title = model.Title,
                    ReleaseDate = model.ReleaseDate,
                    Genres = model.Genres,
                    Actors = model.Actors,
                };

                newMovie.Image = newImage;
                _context.Movies.Add(newMovie);
                await _context.SaveChangesAsync();
            }
            return View();
        }

        private string UploadedFile(MoviePostViewModel model)
        {
            string uniqueImageName = null;

            if(model.MovieImage != null)
            {
                string uploadsLocation = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueImageName = Guid.NewGuid().ToString() + "_" + model.MovieImage.FileName;
                string filePath = Path.Combine(uploadsLocation, uniqueImageName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.MovieImage.CopyTo(fileStream);
                }
            }
            return uniqueImageName;
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            MovieEditViewModel movieEditViewModel = new MovieEditViewModel(movie);
            var currentImage = await _context.Images.FindAsync(movie.Image);
            movieEditViewModel.ImageName = currentImage!=null?currentImage.Name: "No_image_available.svg";
            movieEditViewModel.Actors = movie.Actors;
            return View(movieEditViewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
