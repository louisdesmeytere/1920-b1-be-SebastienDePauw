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

        public int Jaar { get; set; }
        public int Minuten { get; set; }
        public string Categorie { get; set; }
        public DetailDTO Detail { get; set; }

    }
}
