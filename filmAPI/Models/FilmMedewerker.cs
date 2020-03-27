using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class FilmMedewerker
    {
        private int _id;
        private DateTime _geboortedatum;
        private string _naam;
        private int _leeftijd;
        private string _type;
        private ICollection<FilmMedewerkerFilm> _films;

        public int Id {
            get { return _id; }
            set {
                _id = value;
            }
        }

        public ICollection<FilmMedewerkerFilm> Films
        {
            get { return _films; }
            set
            {
                if (value == null) {
                    value = new List<FilmMedewerkerFilm>();
                }
                _films = value;
            }
        }

        public DateTime Geboortedatum
        {
            get { return _geboortedatum; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Medewerker moet een geboortedatum hebben");
                }
                _geboortedatum = value;
            }
        }
        public DateTime? Sterfdatum
        {
            get;
            set;
        }
        public string Naam
        {
            get { return _naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Een Medewerker moet een naam hebben");
                }
                _naam = value;
            }
        }

        public string Geboortestad
        {
            get;
            set;
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Een Medewerker moet een type hebben");
                }
                _type = value;
            }
        }

        private void SetLeeftijd()
        {
            if (Sterfdatum != null)
            {
                var date = Sterfdatum.Value.Date;
                _leeftijd = date.Year - _geboortedatum.Year;
                if (_geboortedatum.Date > date.AddYears(-_leeftijd)) _leeftijd--;
            }
            else
            {
                var today = DateTime.Today;
                _leeftijd = today.Year - _geboortedatum.Year;
                if (_geboortedatum.Date > today.AddYears(-_leeftijd)) _leeftijd--;
            }
        }

        public int GetLeeftijd()
        {
            return _leeftijd;
        }


        public FilmMedewerker(string naam, DateTime geboortedatum, string type, string? geboortestad = "niet bekend", DateTime? sterfdatum = null)
        {
            Naam = naam;
            Geboortedatum = geboortedatum;
            Geboortestad = geboortestad;
            Sterfdatum = sterfdatum;
            Type = type;
            SetLeeftijd();
        }

    }
}
