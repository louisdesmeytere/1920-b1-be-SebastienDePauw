using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class RatingDTO
    {
        public int Score { get; set; }
        public string Beschrijving { get; set; }
        public GebruikerDTO Gebuiker { get; set; }
        public FilmDTO Film { get; set; }
    }
}
