using System.ComponentModel.DataAnnotations;

namespace Filmek.Models
{
    public class Serie
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public Category Categories{ get; set; }
    }
}
