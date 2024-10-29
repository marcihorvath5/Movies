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
        public MovieController(IMovieService ims) 
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

            _ims.saveMovie(movie, SelectedCategories);


            return RedirectToAction("Index");
        }

        // Edit oldal
        public IActionResult Edit(int id)
        {
            var categoriesList = _ims.getCategories().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = $"{c.Id}-{c.Name}"
            }).ToList();

            //ViewData-ként adjuk át a viewnak a kategóriák listáját
            ViewData["c"]= categoriesList;

            Movie movie = _ims.getMovie(id);
            if (movie == null)
            {
                return NoContent();
            }
            return View(movie);
        }

        /// <summary>
        /// Edit page action
        /// Bindingolja a movie propertijeit amik megvannak adva
        /// </summary>
        /// <param name="movie">Film</param>
        /// <param name="SelectedCategories">A kiválasztott kategóriák Id-je</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit([Bind("Id, Title, Year")] Movie movie, List<int> SelectedCategories) 
        {   
            if (movie.Title != null)
            {
                _ims.updateMovie(movie, SelectedCategories);    
            }

            else
            {
                return NoContent();
            }
            

            return RedirectToAction("GetMovie", new{ id = movie.Id });
        }
    }
}
