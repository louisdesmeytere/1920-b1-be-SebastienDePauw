using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Regisseur
    {
        private int _leeftijd;
        public int Id { get; set; }
        public String Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public DateTime? Sterfdatum {get;set;}
        private void SetLeeftijd()
        {
            if (Sterfdatum != null)
            {
                var date = Sterfdatum.Value.Date;
                _leeftijd = date.Year - Geboortedatum.Year;
                if (Geboortedatum.Date > date.AddYears(-_leeftijd)) _leeftijd--;
            }
            else
            {
                var today = DateTime.Today;
                _leeftijd = today.Year - Geboortedatum.Year;
                if (Geboortedatum.Date > today.AddYears(-_leeftijd)) _leeftijd--;
            }
        }
        public int GetLeeftijd()
        {
            return _leeftijd;
        }

        public Regisseur(string naam, DateTime geboortedatum, DateTime? sterfdatum = null)
        {
            Naam = naam;
            Geboortedatum = geboortedatum;
            Sterfdatum = sterfdatum;
            SetLeeftijd();
        }

    }
}
