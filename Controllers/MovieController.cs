using Filmek.Models;
using Filmek.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Filmek.Controllers
{
    public class MovieController : Controller
    {
        /// <summary>
        /// osztályváltozót hozunk létre az interface-nek
        /// </summary>
        private readonly IMovieService _ims;

        /// <summary>
        /// Konstruktor
        /// paraméterként átvesszük az interface-t
        /// </summary>
        /// <param name="ims">A megvalósítandó interface</param>
        public MovieController(IMovieService ims, MovieDb db) 
        {
              _ims = ims;
        }
        /// <summary>
        /// Index oldal
        /// </summary>
        /// <returns>A filmek listájával tér vissza</returns>
        public IActionResult Index()
        {
            return View(_ims.getMovies()); 
        }

        public IActionResult GetMovie(int id) 
        {
            return View(_ims.getMovie(id));
        }

        public IActionResult CreateMovie() 
        {
            // lekérjük a kategória táblából a kategóriákat
            var categories = _ims.getCategories();

            //Majd ezekből SelectListItemet készítünk és ezt adjuk át a viewnak
            var categoriesList = categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = $"{c.Id}-{c.Name}"
            }).ToList();
            return View(categoriesList);
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie, List<int> SelectedCategories)
        {
            // A formtól kapott kategória id-k listájában szereplő id-khez tartozó kategória neveket lekérjük
            // majd összefűzzük őket
            var categories = _ims.getCategories()
                                   .Where(c => SelectedCategories.Contains(c.Id))
                                   .ToList();

            movie.Categories = string.Join(",", categories.Select(cn => cn.Name));

            _ims.saveMovie(movie);

            return RedirectToAction("Index");
        }
    }
}
