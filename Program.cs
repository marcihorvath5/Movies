using Filmek.Models;
using Filmek.Service;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Filmek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IMovieService, MovieService>();



            // példányosítok egy adatbázist így a program további futása során nem lesz rá szükség
            // Adatbázis konfigurálása
            // appsettings.json-ból beolvassok a ConnectionStringet
            builder.Services.AddDbContext<MovieDb>(db => 
                    { 
                        db.UseMySql(builder.Configuration["ConnectionStrings:DefaultConnection"], 
                        ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])); 
                    });

            // kapcsolótábla service hozzáadása
            builder.Services.AddScoped<MovieCategorySyncService>();
            
            

            var app = builder.Build();
             // Kapcsoló tábla szinkronizálás hívása
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var syncService = services.GetRequiredService<MovieCategorySyncService>();
                    syncService.SyncIfEmpty();
                }
                catch (Exception)
                {

                    Console.WriteLine("hiba"); ;
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
