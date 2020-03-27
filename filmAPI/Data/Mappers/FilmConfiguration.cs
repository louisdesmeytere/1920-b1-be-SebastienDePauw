using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Mappers
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("film");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Titel);
            builder.Property(b => b.Beschrijving);
            builder.Property(b => b.Storyline);
            builder.Property(b => b.Categorie);
            builder.Property(b => b.Minuten);
            builder.Property(b => b.Jaar);

            builder.HasMany(b => b.Ratings).WithOne(t => t.Film).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.FilmMedewerkers).WithOne(t => t.Film).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
