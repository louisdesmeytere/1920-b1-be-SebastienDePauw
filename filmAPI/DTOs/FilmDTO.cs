using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class FilmDTO
    {
        public string Titel{ get; set; }
        public string Beschrijving{ get; set; }
        public string Storyline{ get; set; }
        public int Jaar{ get; set; }
        public int Minuten{ get; set; }
        public ICollection<string> Categorie { get; set; }
        public ICollection<FilmMedewerkerDTO> FilmMedewerkers { get; set; }
        public ICollection<RatingDTO> Ratings {get;set;}
    }
}
