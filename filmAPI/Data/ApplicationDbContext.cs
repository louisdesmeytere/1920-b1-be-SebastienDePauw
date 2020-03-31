﻿using filmAPI.Models;
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
        public DbSet<Film> Films { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*           modelBuilder.Entity<Film>().HasMany(p => p.Acteurs).WithOne().IsRequired().HasForeignKey("FilmId");
                       modelBuilder.Entity<Film>().HasMany(p => p.Regisseurs).WithOne().IsRequired().HasForeignKey("FilmId");
                       modelBuilder.Entity<Film>().Property(r => r.Titel).IsRequired().HasMaxLength(50);

                       modelBuilder.Entity<Acteur>().Property(r => r.Naam).IsRequired().HasMaxLength(30);

                       modelBuilder.Entity<Regisseur>().Property(r => r.Naam).IsRequired().HasMaxLength(30);

                       modelBuilder.Entity<Gebruiker>().Property(c => c.Naam).IsRequired().HasMaxLength(30);
                       modelBuilder.Entity<Gebruiker>().Property(c => c.Email).IsRequired().HasMaxLength(50);

                       modelBuilder.Entity<WatchListItem>().HasKey(f => new { f.GebruikerId, f.FilmId });
                       modelBuilder.Entity<WatchListItem>().HasOne(f => f.Gebruiker).WithMany(u => u.WatchList).HasForeignKey(f => f.GebruikerId);
                       modelBuilder.Entity<WatchListItem>().HasOne(f => f.Film).WithMany().HasForeignKey(f => f.FilmId);

                       modelBuilder.Entity<Rating>().HasKey(f => new { f.GebruikerId, f.FilmId });
                       modelBuilder.Entity<Rating>().HasOne(f => f.Gebruiker).WithMany(u => u.Ratings).HasForeignKey(f => f.GebruikerId);
                       modelBuilder.Entity<Rating>().HasOne(f => f.Film).WithMany().HasForeignKey(f => f.FilmId);*/

        }
    }

    }
