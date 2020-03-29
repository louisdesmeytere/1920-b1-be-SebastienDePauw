using filmAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class GebruikerRatingDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double Score { get; set; }

        public GebruikerRatingDTO(Film film, double score)
        {
            Id = film.Id;
            Score = score;
        }
    }
}
