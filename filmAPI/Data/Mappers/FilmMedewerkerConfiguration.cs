using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Mappers
{
    public class FilmMedewerkerConfiguration : IEntityTypeConfiguration<FilmMedewerker>
    {
        public void Configure(EntityTypeBuilder<FilmMedewerker> builder)
        {
            builder.ToTable("filmmedewerker");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Geboortestad).IsRequired(false);
            builder.Property(t => t.Geboortedatum).IsRequired(true);
            builder.Property(t => t.Sterfdatum).IsRequired(false);
            builder.Property(t => t.Naam).IsRequired(true);
            builder.Property(t => t.Type).IsRequired(true);

            builder.HasMany(b => b.Films).WithOne(t => t.FilmMedewerker).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
