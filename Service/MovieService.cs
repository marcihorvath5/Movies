using Filmek.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmek.Service
{
    public class MovieService : IMovieService
    {
        private readonly MovieDb _db;

        /// <summary>
        /// ImovieService metódusainak implementálása
        /// </summary>
        /// <param name="db">paraméterként az adatbázisomat kapja meg</param>
        public MovieService(MovieDb db) 
        {
            _db = db;
        }

        public List<Category> getCategories()
        {
           return _db.Categories.ToList();
        }

        /// <summary>
        /// Vissza adja a kiválasztott filmet a hozzá tartozó kategóriákkal együtt
        /// </summary>
        /// <param name="id">A film azonosítója</param>
        /// <returns></returns>
        public Movie? getMovie(int id)
        {
            
            return _db.Movies.Include(x => x.MovieCategories)
                .ThenInclude(c => c.Category)
                .Where(x => x.Id == id).FirstOrDefault();
;
        }

        public List<Movie> getMovies()
        {
            var list = _db.Movies.Include(x => x.MovieCategories)
                .ThenInclude(c => c.Category)
                .ToList();

            return list;
        }

        public bool saveMovie(Movie movie,List<Category> categories)
        {

            try
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();

                foreach (var c in categories)
                {
                    movie.MovieCategories.Add(new MovieCategory
                    {
                        Movie = movie,
                        Category = c

                    });    
                }

                _db.SaveChanges();

            }

            catch(Exception ex) 
            {
                Console.WriteLine(ex.InnerException.Message);
                Console.ReadLine();
               
                return false;
            }

            return true;
        }
    }
}
