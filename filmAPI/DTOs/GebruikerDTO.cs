using filmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class GebruikerDTO
    {
        public string Naam { get; set; }
        public string Email { get; set; }
        public IList<FilmDTO> Watchlist { get; set; }
    }
}
