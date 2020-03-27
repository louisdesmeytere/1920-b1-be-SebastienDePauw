using filmAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Data.Mappers
{
    public class FilmMedewerkerFilmConfiguration : IEntityTypeConfiguration<FilmMedewerkerFilm>
    {
        public void Configure(EntityTypeBuilder<FilmMedewerkerFilm> builder)
        {
            builder.HasKey(b => new { b.FilmId, b.FilmMedewerkerId });

            builder.HasOne(b => b.Film).WithMany(b => b.FilmMedewerkers).HasForeignKey(g => g.FilmId);
            builder.HasOne(b => b.FilmMedewerker).WithMany(b => b.Films).HasForeignKey(b => b.FilmMedewerkerId);
        }
    }
}
