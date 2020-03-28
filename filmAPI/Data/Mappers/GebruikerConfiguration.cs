using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Mappers
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
/*            builder.ToTable("gebruiker");

            builder.HasKey(g => g.Id);

            builder.Property(b => b.Naam);
            builder.Property(b => b.Email);

            builder.HasMany(b => b.Watchlist).WithOne().IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Seenlist).WithOne().IsRequired(false).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Ratings).WithOne(b => b.Gebruiker).IsRequired(false).OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
