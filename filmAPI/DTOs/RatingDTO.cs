using filmAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class RatingDTO
    {
        [Required]
        public Gebruiker Gebruiker { get; set; }

        [Required]
        public double Score { get; set; }

    }
}
