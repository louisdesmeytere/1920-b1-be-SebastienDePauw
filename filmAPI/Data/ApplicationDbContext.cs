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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>()
                            .HasMany(p => p.Acteurs)
                            .WithOne()
                            .IsRequired()
                            .HasForeignKey("FilmId");

            modelBuilder.Entity<Film>()
                .HasOne(p => p.Regisseur)
                .WithMany()
                .IsRequired()
                .HasForeignKey("FilmId");

            modelBuilder.Entity<Film>().Property(r => r.Titel).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Acteur>().Property(r => r.Naam).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Regisseur>().Property(r => r.Naam).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Gebruiker>().Property(c => c.Naam).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Gebruiker>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Gebruiker>().Ignore(c => c.RatedMovies);

            modelBuilder.Entity<GebruikerRating>().HasKey(f => new { f.GebruikerId, f.FilmId });
            modelBuilder.Entity<GebruikerRating>().HasOne(f => f.Gebruiker).WithMany(u => u.Ratings).HasForeignKey(f => f.GebruikerId);
            modelBuilder.Entity<GebruikerRating>().HasOne(f => f.Film).WithMany().HasForeignKey(f => f.FilmId);

        }
    }

    }
