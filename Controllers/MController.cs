using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vid.Models;
using Vid.ViewModels;
using System.Data.Entity;

namespace Vid.Controllers
{
    public class MController : Controller
    {
        private ApplicationDbContext _context;

        public MController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: M
        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };
            if (User.IsInRole(RoleName.CanManageMovies)) return View("List",viewModel);
            return View("ReadOnlyList",viewModel);
            
        }
        [Route("Movies/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genres = _context.Genres.ToList()

                };
                return View("MovieForm",viewModel);
            }
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null) return HttpNotFound();
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel(movie)
            {
                

                Genres=genres
            };
            return View("MovieForm", viewModel);
        }
        
    }
}