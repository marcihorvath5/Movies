using Filmek.Service;
using Microsoft.AspNetCore.Mvc;

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
    }
}
