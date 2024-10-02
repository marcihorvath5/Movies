using System.ComponentModel.DataAnnotations;

namespace Filmek.Models
{
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

    }
}
