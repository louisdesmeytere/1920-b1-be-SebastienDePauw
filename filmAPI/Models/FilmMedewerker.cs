using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class FilmMedewerker
    {
        private DateTime _geboortedatum;
        private string _naam;
        private int _leeftijd;
        private string _type;
        private string _rol;

        public int Id {
            get;
            set;
        }
        public string Rol {
            /*            get { return _rol; }
                        set {
                            if(value != null) {
                                if (_type.ToLower().Equals("acteur"))
                                {
                                    _rol = value;
                                }
                                else { throw new ArgumentException("Alleen een acteur mag een rol hebben"); }
                            }
                            else {
                                throw new ArgumentException("Een acteur moet een rol spelen");
                            }
                        } */
            get;set;
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


        public FilmMedewerker(string naam, DateTime geboortedatum, string type,  string? geboortestad = "niet bekend", DateTime? sterfdatum = null, string? rol = null)
        {
            Naam = naam;
            Geboortedatum = geboortedatum;
            Geboortestad = geboortestad;
            Sterfdatum = sterfdatum;
            Type = type;
            Rol = rol;
            SetLeeftijd();
        }
    }
}
