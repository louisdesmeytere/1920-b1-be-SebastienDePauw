using filmAPI.Data.Mappers;
using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Film> Films { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<FilmMedewerker> FilmMedewerkers { get; set; }
        public DbSet<Categorie> Categorieen { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GebruikerConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new FilmMedewerkerConfiguration());
            modelBuilder.ApplyConfiguration(new CategorieConfiguration());
        }

    }
}
