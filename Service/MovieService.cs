using Filmek.Models;

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

        public Movie getMovie(int id)
        {
            return _db.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> getMovies()
        {
            return _db.Movies.ToList();
        }

        public bool saveMovie(Movie movie)
        {
            try
            {
                _db.Movies.Add(movie);
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
