using Microsoft.EntityFrameworkCore;

namespace Filmek.Models
{
    /// <summary>
    /// MovieDb osztály létrehozása
    /// leszármaztatása DbContextből
    /// DbSetek(táblák) meghatározása
    /// </summary>
    public class MovieDb : DbContext
    {
        // ConnectionString Server,Adatbázis név megadása
        private string c = "Server=localhost;Database=MovieDb;Uid=root;Pwd=";

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        // Adatbázis konfigurálása
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(c,ServerVersion.AutoDetect(c));
        }
    }
}
