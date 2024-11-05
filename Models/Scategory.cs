using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmek.Models
{
    public class Scategory
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

        public ICollection<SerieCategory>? SerieCategories { get; set; }
    }
}
