namespace Filmek.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        /// <summary>
        /// Össze kapcsoljuk a filmid-vel a kommentet
        /// </summary>
        //public Movie Movie { get; set; }
    }
}
