using System.ComponentModel.DataAnnotations;

namespace Filmek.Models
{
    /// <summary>
    /// Filmek osztálya és property-jei
    /// </summary>

    public class Movie
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        /// <summary>
        /// össze kapcsolás a ketegória id-jével
        /// </summary>
        public Category Categories { get; set; }

        /// <summary>
        /// Kollekcióba("listába") gyűjti a kommenteket 
        /// így létrehozható egy a többhöz kapcsolat 
        /// tehát egy filmhez több komment is tartozhat
        /// </summary>
        public ICollection<Comment> Movies { get; set; }


    }
}
