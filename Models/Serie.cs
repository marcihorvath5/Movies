using System.ComponentModel.DataAnnotations;

namespace Filmek.Models
{   
    /// <summary>
    /// Sorozatok osztálya és property-jei
    /// </summary>
    public class Serie
    {

        [Key]
        public int Id { get; set; }

        // Annotációval módosítható a propertik viselkedése és megadható a velük szembeni elvárás 
        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public ICollection<SerieComment> SerieComments { get; set; } = new List<SerieComment>();

        public ICollection<SerieCategory> SerieCategories {get; set; } = new List<SerieCategory>();
    }
}
