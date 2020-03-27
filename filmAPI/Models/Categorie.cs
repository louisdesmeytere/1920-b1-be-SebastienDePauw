using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Categorie
    {
        private Genres _genres;
        private string _beschrijving;

        public string Beschrijving
        {
            get { return _beschrijving; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Een categorie moet een beschrijving hebben.");
                }
                else if (value.Length > 5000) {
                    throw new ArgumentException("Beschrijving mag maximaal 5000 karakters lang zijn. U heeft er momenteel " + value.Length);
                }
                else
                {
                    _beschrijving = value;
                }
            }
        }
        public Genres Genre {
            get;
            set;
        }

        public Categorie(Genres genre, string beschrijving)
        {
            Beschrijving = beschrijving;
            Genre = genre;
        }
    }
}
