using Filmek.Models;

namespace Filmek.Service
{
    public class MovieCategorySyncService
    {
        public readonly MovieDb _context;

        public MovieCategorySyncService(MovieDb context) 
        {
            _context = context;
        }

        /// <summary>
        /// Ha még nincs feltöltve a kapcsolótábla
        /// akkor feltöltjük
        /// </summary>
        public void SyncIfEmpty() 
        {
            var isEmpty = !_context.MovieCategories.Any();

            if (isEmpty)
            {
                Sync();
            }
        }

        private void Sync()
        {
            // Filmek listába töltése
            var movies = _context.Movies.ToList();

            foreach (var movie in movies)
            {
                ///Kategóriák betöltése
                ///white-space karakterek eltávolítása(string.trim())
                ///Karakterek amelyek nem "üresek" vagy white-space-ek listába gíűjtése
                var categoryNames = movie.Categories.Split(',')
                                                      .Select(c => c.Trim())
                                                      .Where(c => !string.IsNullOrWhiteSpace(c))
                                                      .ToList();
                foreach (var categoryName in categoryNames)
                {
                    // Kategória megkeresése az adatnázisból
                    var category = _context.Categories.FirstOrDefault(c => c.Name.Trim() == categoryName.Trim());
                    if (category != null)
                    {
                        // Ha van találat akkor
                        // hozzáadjuk a film id-jét illetve a ketegória id-jét a MovieCategory táblához
                        if (!_context.MovieCategories.Any(mc => mc.MovieId == movie.Id && mc.CategoryId == category.Id))
                        {
                            var movieCategory = new MovieCategory
                            {
                                MovieId = movie.Id,
                                CategoryId = category.Id
                            };

                            _context.MovieCategories.Add(movieCategory);
                        }
                    }
                }
            }
            _context.SaveChanges();
        }
    }
}
