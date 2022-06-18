using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using Movie_Ecommerce.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Controllers
{

    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.Include(c => c.Cinema).OrderBy(n => n.Name).ToListAsync());
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _context.Movies.Include(c => c.Cinema).OrderBy(n => n.Name).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //GET: Movies/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _context.Movies
                             .Include(c => c.Cinema)
                             .Include(p => p.Producer)
                             .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                             .FirstOrDefaultAsync(n => n.Id == id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return View(movieDetails);
        }

        //GET: Movies/Create
        public IActionResult Create()
        {


            ViewBag.Cinemas = new SelectList(_context.Cinemas.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "FullName");
            ViewBag.Actors = new SelectList(_context.Actors.ToList(), "Id", "FullName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (ModelState.IsValid)
            {
                var newMovie = new Moviee()
                {
                    Name = movie.Name,
                    Description = movie.Description,
                    Price = movie.Price,
                    ImageUrl = movie.ImageURL,
                    CinemaId = movie.CinemaId,
                    StartDate = movie.StartDate,
                    EndDate = movie.EndDate,
                    MovieCategory = movie.MovieCategory,
                    ProducerId = movie.ProducerId
                };

                await _context.Movies.AddAsync(newMovie);
                 await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            ViewBag.Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            ViewBag.Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();
            return View(movie);
        }


        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _context.Movies
                 .Include(c => c.Cinema)
                 .Include(p => p.Producer)
                 .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                 .FirstOrDefaultAsync(n => n.Id == id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };


            ViewBag.Cinemas = new SelectList(_context.Cinemas.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "FullName");
            ViewBag.Actors = new SelectList(_context.Actors.ToList(), "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return NotFound();

            }

            if (ModelState.IsValid)
            {
                var dbMovie = await _context.Movies
                 .Include(c => c.Cinema)
                 .Include(p => p.Producer)
                 .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                 .FirstOrDefaultAsync(n => n.Id == id);

                if (dbMovie != null)
                {
                    dbMovie.Name = movie.Name;
                    dbMovie.Description = movie.Description;
                    dbMovie.Price = movie.Price;
                    dbMovie.ImageUrl = movie.ImageURL;
                    dbMovie.CinemaId = movie.CinemaId;
                    dbMovie.StartDate = movie.StartDate;
                    dbMovie.EndDate = movie.EndDate;
                    dbMovie.MovieCategory = movie.MovieCategory;
                    dbMovie.ProducerId = movie.ProducerId;
                }
                _context.Movies.Update(dbMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            ViewBag.Cinemas = new SelectList(_context.Cinemas.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "FullName");
            ViewBag.Actors = new SelectList(_context.Actors.ToList(), "Id", "FullName");
            return View(movie);
        }


    }
}