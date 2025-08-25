using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cfirst.Models;
using Cfirst.Repository;
namespace Cfirst.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController()
        {
            movieRepository = new MovieRepository();
        }

        // Display all movies
        public ActionResult Index()
        {
            var movies = movieRepository.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View(new Movie()); // Pass a new instance of Movie
        }


        // Create a new movie
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Create(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movie = movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        // Edit a movie
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Edit(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Delete(int id)
        {
            var movie = movieRepository.GetById(id);
            
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction("Index");
        }






        // Display movies by year
        public ActionResult MoviesByYear(int year)
        {
            
            var movies = movieRepository.GetAllMoviesByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = movieRepository.GetMoviesByDirector(directorName);
            return View(movies);
        }

    }
}