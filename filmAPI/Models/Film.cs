using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Film
    {
        private int _id;
        private string _titel;
        private string _beschrijving;
        private string _storyline;
        private int _jaar;
        private int _minuten;
        private List<string> _categorie;
        private List<FilmMedewerkerFilm> _filmMedewerkers;
        private ICollection<Rating> _ratings;

        public int Id { get; set; }

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
        public List<string> Categorie {
            get { return _categorie; }
            set {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Geef een of meerdere geldige categorieën");
                }
                _categorie = value;
            }
        }
        public List<FilmMedewerkerFilm> FilmMedewerkers
        {
            get { return _filmMedewerkers; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Een film heeft minimaal 1 acteur");
                }
                _filmMedewerkers = value;
            }
        }
        public ICollection<Rating> Ratings
        {
            get { return _ratings; }
            set
            {
                if (value == null)
                {
                    value = new List<Rating>();
                }
                _ratings = value;
            }
        }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, string[] categorie, FilmMedewerkerFilm[]filmMedewerkers, ICollection<Rating>? rating = null)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Storyline = storyline;
            Jaar = jaar;
            Minuten = minuten;
            Categorie = new List<string>(categorie);
            FilmMedewerkers = new List<FilmMedewerkerFilm>(filmMedewerkers);
            Ratings = rating;
        }

        public void AddCategorie(string categorie) {
            Categorie.Add(categorie);
        }

        public void AddFilmMedewerker(FilmMedewerker filmMedewerker) {
            FilmMedewerkers.Add(filmMedewerker);
        }

        public void RemoveCategorie(string categorie)
        {
            Categorie.Remove(categorie);
        }

        public void RemoveCategorie(FilmMedewerker filmMedewerker)
        {
            FilmMedewerkers.Remove(filmMedewerker);
        }

        public string GetByCategorie(string categorie) {
            return Categorie.FirstOrDefault(b => b == categorie);
        }

        public FilmMedewerker GetByFilmMedewerker(string type)
        {
            return FilmMedewerkers.FirstOrDefault(b => b.Type == type);
        }


    }
}
