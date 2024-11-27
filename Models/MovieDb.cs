using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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
        private readonly IConfiguration _configuration;
        
        //Iconfigurationtt injektáljuk az adatbázis konfigurációjához
        public MovieDb(IConfiguration configuration, DbContextOptions<MovieDb> db): base(db)
        {
        
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<MovieCategory> MovieCategories { get; set; }

        public DbSet<SerieCategory> SerieCategories { get; set; }

        public DbSet<SerieComment> SerieComments { get; set; }

        public DbSet<Scategory> Scategories { get; set; }

        /// <summary>
        /// Több a többhöz kapcsolat fluent apival
        /// a filmek és a kategóriák között
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasKey(x => new { x.MovieId, x.CategoryId});
            modelBuilder.Entity<MovieCategory>().HasOne(y => y.Movie)
                                                .WithMany(m => m.MovieCategories)
                                                .HasForeignKey(mo => mo.MovieId);

            modelBuilder.Entity<MovieCategory>().HasOne(y => y.Category)
                                                .WithMany(c => c.MovieCategories)
                                                .HasForeignKey(ca => ca.CategoryId);

            modelBuilder.Entity<SerieCategory>().HasKey(x => new { x.SerieId, x.CategoryId});
            modelBuilder.Entity<SerieCategory>().HasOne(s => s.Serie)
                                                .WithMany(sc => sc.SerieCategories)
                                                .HasForeignKey(se => se.SerieId);
            
            modelBuilder.Entity<SerieCategory>().HasOne(c => c.Scategory)
                                                .WithMany(sc => sc.SerieCategories)
                                                .HasForeignKey(ca => ca.CategoryId);
        }

    }
}
