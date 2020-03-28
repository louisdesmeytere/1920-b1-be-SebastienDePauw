using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class FilmMedewerkerDTO
    {
        public ICollection<FilmDTO> Film { get; set; }
        public DateTime Geboortedatum{get; set;}
        public DateTime Sterfdatum{get;set;}
        public string Naam{get;set;}

        public string Geboortestad{get;set;}

        public string Type{get;set; }
    }
}
