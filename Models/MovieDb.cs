using Microsoft.EntityFrameworkCore;

namespace Filmek.Models
{
    public class MovieDb : DbContext
    {
        private string c = "Server=localhost;Database=MovieDb;Uid=root;Pwd=";

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(c,ServerVersion.AutoDetect(c));
        }
    }
}
