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
                .Include(x => x.Comments)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Movie> getMovies()
        {
            var list = _db.Movies.Include(x => x.MovieCategories)
                .ThenInclude(c => c.Category)
                .ToList();

            return list;
        }

        public bool saveMovie(Movie movie,List<int> SelectedCategories)
        {

            try
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();

                // Listát csinálunk a kiválasztott kategóriákból
                List<Category> categories = getCategories()
                                            .Where(c => SelectedCategories.Contains(c.Id))
                                            .ToList();

                // Majd ezen a listán végig megyünk és a filmh Movicategories kollekciójához adjuk
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

        public bool updateMovie(Movie movie, List<int> categories)
        {
            try
            {
                // Lekérjük az adatbázisban már meglévő entitást aminek az id-je
                // egyezik a paraméterként kapott filmével
                Movie m = _db.Movies.Include(x => x.MovieCategories).FirstOrDefault(m => m.Id == movie.Id);
                List<Category> selectedCategories = getCategories().Where(c => categories.Contains(c.Id))
                                                                                                .ToList();
                // Frissítjük a meglévő entitást
                m.Title = movie.Title;
                m.Year = movie.Year;

                // Meglévő kategóriák törlése
                m.MovieCategories.Clear();
                // új kategóriák hozzáadása
                foreach (Category c in selectedCategories)
                {
                    m.MovieCategories.Add(new MovieCategory
                    {
                        Movie = m,
                        Category = c,
                    });
                }

                _db.Movies.Update(m);
                _db.SaveChanges();
                
                return true;
            }
            catch (System.Exception)
            {       
                return false;
            }
        }

        /// <summary>
        /// Komment hozzáadása egy filmhez
        /// </summary>
        /// <param name="movie">Az adott film</param>
        /// <param name="comment">A beírt komment</param>
        public void addComment(Movie movie, string comment)
        {
            Movie m = getMovie(movie.Id);
            m.Comments.Add(new Comment
            {
                Content = comment
            });

            _db.Movies.Update(m);
            _db.SaveChanges();
        }
    }
}