using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class FilmDTO
    {
        [Required]
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string Storyline { get; set; }
        public int Jaar { get; set; }
        public int Minuten { get; set; }
        public string Categorie { get; set; }
        public double? Rating { get; set; }
        public IList<RegisseurDTO> Regisseurs { get; set; }
        public IList<ActeurDTO> Acteurs { get; set; }
    }
}
