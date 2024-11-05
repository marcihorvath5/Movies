namespace Filmek.Models
{
    public class SerieCategory
    {
        public int SerieId { get; set;}
        public Serie Serie{ get; set;}

        public int CategoryId { get; set;}
        public Category Category{ get; set;}
    }
}