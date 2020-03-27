using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Rating
    {
        private double _score;
        private string _beschrijving;
        private Gebruikers _gebruiker;
        private Film _film;

        public double Score {
            get { return _score; }
            set {
                if (double.IsNegative(value))
                {
                    throw new ArgumentException("Score moet groter zijn als 0");
                }
                else if (value > 10) {
                    throw new ArgumentException("Score moet kleiner zijn als 10");
                }
                else if (double.IsNaN(value))
                {
                    throw new ArgumentException("Score moet een getal zijn.");
                }
                else
                {
                    _score = value;
                }
            }
        }

        public string Beschrijving {
            get { return _beschrijving; }
            set {
                if (value.Length > 500)
                {
                    throw new ArgumentException("Beschrijving mag maximaal 500 karakters lang zijn. U heeft er momenteel " + value.Length);
                }
                    _beschrijving = value;

            }
        }

        public Gebruikers Gebruiker {
            get { return _gebruiker; }
            set {
                if (value == null) {
                    throw new ArgumentException("Een rating moet een gebruiker hebben");
                }
                _gebruiker = value;
            }
        }

        public Film Film {
            get { return _film; }
            set {
                if (value == null) {
                    throw new ArgumentException("Een rating moet verbonden zijn aan een film");
                }
                _film = value;
            }
        
        }

        public Rating(double score, Gebruikers gebruiker, Film film, string? beschrijving = null)
        {
            Score = score;
            Beschrijving = beschrijving;
            Gebruiker = gebruiker;
            Film = film;
        }
    }
}
