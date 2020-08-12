using filmAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Film> Films { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>().Property(p => p.Categorie).IsRequired(true);

            modelBuilder.Entity<Gebruiker>().Property(p => p.Email).IsRequired(true);
            modelBuilder.Entity<Gebruiker>().Property(p => p.Naam).IsRequired(true);

            modelBuilder.Entity<Regisseur>().Property(p => p.Naam).IsRequired(true);

            modelBuilder.Entity<Acteur>().Property(p => p.Naam).IsRequired(true);
        }
    }

    }
