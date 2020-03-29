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

        public int Id {get;set;}
        public DateTime Created { get; set; }
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
        public List<WatchListItem> WatchList { get;set; }
        public ICollection<Rating> Ratings { get; set; }

        public Gebruiker() {
            WatchList = new List<WatchListItem>();
            Ratings = new List<Rating>();
            Created = DateTime.Now;
        }

        public Gebruiker(string naam, string email) : this()
        {
            Naam = naam;
            Email = email;
        }

        public Dictionary<Film, double> GetMijnRatings() {
            var map = new Dictionary<Film, double>();
            List<Rating> ratings = new List<Rating>(Ratings);
            ratings.ForEach(e => map.Add(e.Film, e.Score));
            return map;
        }

        public void AddFilmWatchlist(Film film)
        {
            if (film != null) RemoveFilmWatchList(film);
            WatchList.Add(new WatchListItem() { FilmId = film.Id, GebruikerId = Id, Film = film, Gebruiker = this});
        }
        public void AddRating(Film film, int score) {
            RemoveRating(film);
            Ratings.Add(new Rating() { FilmId = film.Id, GebruikerId = Id, Film = film, Gebruiker = this, Score = score });
        }

        public void RemoveFilmWatchList(Film film) { 
            WatchList.Where(e => e.GebruikerId == Id && e.FilmId == film.Id).ToList().ForEach(e => WatchList.Remove(e));
        }
        public void RemoveRating(Film film) { 
            Ratings.Where(e => e.GebruikerId == Id && e.FilmId == film.Id).ToList().ForEach(e => Ratings.Remove(e)); 
        }

        public List<Film> GetFilmsWatchedOpTitel(string titel) => WatchList.Select(r => r.Film).Where(i => i.Titel.Contains(titel.ToLower().Trim())).ToList();
        public List<Film> GetAllFilmsWatchList() => WatchList.Select(r => r.Film).ToList();
        public List<Film> GetAllGeratedFilms() => Ratings.Select(r => r.Film).ToList();
    }
}
