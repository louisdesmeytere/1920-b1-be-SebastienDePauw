using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Film
    {
        private string _titel;
        private string _beschrijving;
        private string _storyline;
        private int _jaar;
        private int _minuten;
        private List<Categorie> _categorie;
        private List<string> _schrijvers;
        private List<string> _regisseurs;
        private List<string> _acteurs;

        public string Titel {
            get { return _titel; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Titel mag niet leeg zijn");
                }
                    _titel = value;
            } 
        }
        public string Beschrijving {
            get { return _beschrijving; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Beschrijving mag niet leeg zijn");
                }
                    _beschrijving = value;
            }
        }

        public string Storyline
        {
            get { return _storyline; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Storyline mag niet leeg zijn");
                }
                _storyline = value;
            }
        }
        public int Jaar {
            get {
                return _jaar;
            }
            set {
                if (value < 1880) {
                    throw new ArgumentException("Verkeerd jaar");
                }
                if (value > DateTime.Now.Year+3)
                {
                    throw new ArgumentException("Film kan niet meer als 3 jaar in de toekomst liggen");
                }
                if (double.IsNaN(value)) {
                    throw new ArgumentException("Geef een geldig jaar in");
                }
                _jaar = value;
            } 
        }
        public int Minuten {
            get { return _minuten; }
            set {
                if (double.IsNaN(value)) {
                    throw new ArgumentException("Geef een geldig aantal minuten in");
                }
                if (value > int.MaxValue) {
                    throw new ArgumentException("Film duurt te lang");
                }
                _minuten = value;
            }
        }
        public List<Categorie> Categorie {
            get { return _categorie; }
            set {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Geef een of meerdere geldige categorieën");
                }
                _categorie = value;
            }
        }
        public List<string> Schrijvers {
            get { return _schrijvers; }
            set {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Een film heeft minimaal 1 schrijver");
                }
                _schrijvers = value;
                    }
        }
        public List<string> Regisseurs {
            get { return _regisseurs; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Een film heeft minimaal 1 regisseur.");
                }
                _regisseurs = value;
            }
        }
        public List<string> Acteurs {
            get { return _acteurs; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Een film heeft minimaal 1 acteur");
                }
                _acteurs = value;
            }
        }
        public Rating Rating { get; set; }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, Categorie[] categorie, string[] schrijvers, string[] regisseurs, string[] acteurs, Rating? rating = null)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Storyline = storyline;
            Jaar = jaar;
            Minuten = minuten;
            Categorie = new List<Categorie>(categorie);
            Schrijvers = new List<string>(schrijvers);
            Regisseurs = new List<string>(regisseurs);
            Acteurs = new List<string>(acteurs);
            Rating = rating;
        }
    }
}
