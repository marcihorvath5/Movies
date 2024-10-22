using Filmek.Models;

namespace Filmek.Service
{
    public interface IMovieService
    {
        public List<Movie> getMovies();
        public Movie getMovie(int id);
        public bool saveMovie(Movie movie, List<Category> cat);
        public List<Category> getCategories();
    }
}
