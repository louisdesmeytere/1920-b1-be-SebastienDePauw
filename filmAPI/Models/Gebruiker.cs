using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Gebruiker
    {
        private string _naam;
        private MailAddress _email;
        private ICollection<Film> _watchlist;
        private ICollection<Film> _seenlist;
        private DateTime _created;
        private Dictionary<Film, double> _ratings;

        public int Id {get;set;}
        public DateTime Created {
            get { return _created; }
            set {
                if (value == null) {
                    _created = DateTime.Today;
                }
            }
        }
        public string Naam {
            get { return _naam; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _naam = value;
                } else {
                    throw new ArgumentException("Naam mag niet leeg zijn.");
                }
            }
        }
        public string Email { 
            get { return _email.Address; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        _email = new MailAddress(value);
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException("Email addres heeft een verkeerd formaat.");
                    }
                }
                else
                {
                    throw new ArgumentException("Naam mag niet leeg zijn.");
                }
            }
        }
        public ICollection<Film> SeenList {
            get { return _watchlist; }
            set
            {
                if (value == null)
                {
                    value = new List<Film>();
                }
                    _watchlist = value;
            }
        }
        public ICollection<GebruikerRating> Ratings { get; set; }

        public Gebruiker() {
            SeenList = new List<Film>();
        }

        public Gebruiker(string naam, string email)
        {
            Naam = naam;
            Email = email;
            Ratings = new List<GebruikerRating>();
            Created = DateTime.Now;
        }

        public Dictionary<Film, double> GetMijnRatings() {
            var map = new Dictionary<Film, double>();
            List<GebruikerRating> ratings = new List<GebruikerRating>(Ratings);
            ratings.ForEach(e => map.Add(e.Film, e.Rating));
            return map;
        }

        public void AddFilmWatchlist(Film film)
        {
            Film f = SeenList.FirstOrDefault(film => film.Id == film.Id);
            if (f != null) RemoveFilmWatchList(f);
            SeenList.Add(film);
        }
        public void AddRating(Film film, int score) {
            RemoveRating(film);
            Ratings.Add(new GebruikerRating() { FilmId = film.Id, GebruikerId = Id, Film = film, Gebruiker = this, Rating = score });
        }

        public void RemoveFilmWatchList(Film film) => SeenList.Remove(film);
        public void RemoveRating(Film film) { 
            Ratings.Where(e => e.GebruikerId == Id && e.FilmId == film.Id).ToList().ForEach(e => Ratings.Remove(e)); 
        }

        public IEnumerable<Film> GetFilmsWatchedOpTitel(string titel) => SeenList.Where(i => i.Titel.Contains(titel.ToLower().Trim()));
        public List<Film> GetAllGeratedFilms() => Ratings.Select(r => r.Film).ToList();
    }
}
