namespace Filmek.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ICollection<Movie> Comments { get; set; }

        public Movie Movie { get; set; }
    }
}
