using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmek.Models
{
    /// <summary>
    /// Kategóriák osztálya
    /// </summary>
    public class Category
    {
        public int Id { get; set; }

        /// <summary>
        /// Az adatbázisban módosítjuk a mező nevét
        /// Megszabjuk hogy kötelező megadni => not null
        /// </summary>
        [Column("CategoryName")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// MovieCategory Icollection a szükséges kapcsolat létrehozásához
        /// </summary>
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
