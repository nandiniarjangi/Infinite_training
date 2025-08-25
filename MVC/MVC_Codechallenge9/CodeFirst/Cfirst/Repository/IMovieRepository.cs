using Cfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cfirst.Repository
{
    interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMoviesByYear(int year);

        IEnumerable<Movie> GetAll();

        Movie GetById(int id);
        void Create(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
        object GetMoviesByDirector(string directorName);
    }
}