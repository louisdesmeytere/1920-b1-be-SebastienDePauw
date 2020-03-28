using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        private ICollection<String> _categorie;

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
        public string Categorie {
            get;set;
        }
        public ICollection<FilmMedewerker> FilmMedewerker { get; set; }
        public ICollection<Rating> Ratings{get;set;}

        public Film() {
        }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, string categorie,ICollection<FilmMedewerker> filmMedewerkers) : this()
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Storyline = storyline;
            Jaar = jaar;
            Minuten = minuten;
            Categorie = categorie;
            FilmMedewerker = filmMedewerkers;
        }

        public Film(string titel, string beschrijving, string storyline, int jaar, int minuten, ICollection<String> categorie, ICollection<FilmMedewerker> filmMedewerkers, ICollection<Rating> rating) : this(titel, beschrijving, storyline, jaar, minuten, categorie, filmMedewerkers)
        {
            Ratings = rating;
        }

        public void AddCategorie(string categorie) {
            Categorie.Add(categorie);
        }

        public void AddFilmMedewerker(FilmMedewerker filmMedewerker) {
            FilmMedewerker.Add(filmMedewerker);
        }

        public void AddRating(Rating rating) {
            Ratings.Add(rating);
        }

        public void RemoveCategorie(string categorie)
        {
            Categorie.Remove(categorie);
        }

        public void RemoveFilmMedewerker(FilmMedewerker filmMedewerker)
        {
            FilmMedewerker.Remove(filmMedewerker);
        }

        public void Remove(Rating rating)
        {
            Ratings.Add(rating);
        }

        public string GetByCategorie(string categorie) {
            return Categorie.FirstOrDefault(b => b == categorie);
        }

        public FilmMedewerker GetByFilmMedewerker(string type)
        {
            return  FilmMedewerker.FirstOrDefault(b => b.Type == type);
        }


    }
}
