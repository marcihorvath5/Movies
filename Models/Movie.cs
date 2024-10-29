using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmek.Models
{
    /// <summary>
    /// Filmek osztálya és property-jei
    /// </summary>

    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public int Length { get; set; }

        public string? Picture { get; set; }

        public string? Publisher { get; set; }

        /// <summary>
        /// össze kapcsolás a ketegória id-jével
        /// </summary>
        //public Category Category { get; set; }

        /// <summary>
        /// Kollekcióba("listába") gyűjti a kommenteket 
        /// így létrehozható egy a többhöz kapcsolat 
        /// tehát egy filmhez több komment is tartozhat
        /// </summary>
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        /// <summary>
        /// MovieCategory Icollection a szükséges kapcsolat létrehozásához
        /// </summary>
        public ICollection<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
    }
}
