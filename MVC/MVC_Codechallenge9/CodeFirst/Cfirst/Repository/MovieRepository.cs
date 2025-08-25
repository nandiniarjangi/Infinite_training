using System;
using System.Collections.Generic;
using System.Linq;
using Cfirst.Models;

namespace Cfirst.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db;

        public MovieRepository()
        {
            db = new MovieContext();
        }

        public void Create(Movie movie)
        {
            db.movie.Add(movie);
            db.SaveChanges();
        }

        public void Edit(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.movie.ToList();
        }

        public Movie GetById(int id)
        {
            return db.movie.Find(id);
        }

        public IEnumerable<Movie> GetAllMoviesByYear(int year)
        {
            return db.movie.Where(m => m.DateofRelease.Year == year).ToList();
        }

        public IEnumerable<Movie> GetMoviesByDirector(string directorName)
        {
            return db.movie.Where(m => m.DirectorName == directorName).ToList();
        }

        public void Delete(int id)
        {
            var movie = db.movie.Find(id);
            if (movie != null)
            {
                db.movie.Remove(movie);
                db.SaveChanges();
            }
        }

        object IMovieRepository.GetMoviesByDirector(string directorName)
        {
            throw new NotImplementedException();
        }
    }
}
