using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class DetailDTO
    {
        public string Beschrijving { get; set; }
        public string Storyline { get; set; }
        public double? Rating { get; set; }
        public IList<RegisseurDTO> Regisseurs { get; set; }
        public IList<ActeurDTO> Acteurs { get; set; }
    }
}
