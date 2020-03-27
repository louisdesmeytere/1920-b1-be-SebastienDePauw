using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class FilmMedewerkerFilm
    {
        public int FilmMedewerkerId { get; set; }
        public FilmMedewerker FilmMedewerker { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
