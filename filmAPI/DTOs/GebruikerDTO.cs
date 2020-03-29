using filmAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.DTOs
{
    public class GebruikerDTO
    {
        public DateTime Created { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public ICollection<Film> SeenList { get; set; }
        public Dictionary<Film, double> MijnRatings { get; set; }

        public GebruikerDTO() { }

        public GebruikerDTO(Gebruiker gebruiker) : this() {
            Naam = gebruiker.Naam;
            Email = gebruiker.Email;
            SeenList = gebruiker.SeenList;
            MijnRatings = gebruiker.GetMijnRatings();
        }
    }
}
