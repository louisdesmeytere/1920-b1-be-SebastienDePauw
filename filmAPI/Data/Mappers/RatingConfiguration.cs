using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Mappers
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("rating");

            builder.HasKey(b => b.Id);

            builder.Property(t => t.Score).IsRequired(true);
            builder.Property(t => t.Beschrijving).IsRequired(false);

            builder.HasOne(b => b.Film).WithMany(t => t.Ratings).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.Gebruiker).WithMany(t => t.Ratings).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
