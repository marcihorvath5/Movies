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
        /// Megszabjuk hogy kötelező megadin => not null
        /// </summary>
        [Column("CategoryName")]
        [Required]
        public string Name { get; set; }

    }
}
